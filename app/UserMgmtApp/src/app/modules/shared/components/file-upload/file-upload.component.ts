import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent implements OnInit {

  @Output() closeComponentEmitter = new EventEmitter<boolean>();

  public fileData: File = null;
  public previewUrl: any = null;
  public fileUploadProgress: string = null;
  public uploadedFilePath: string = null;

  constructor(
    private httpClient: HttpClient,

  ) { }

  public ngOnInit(): void {

  }

  public fileProgress(fileInput: any): void {
    this.fileData = <File>fileInput.target.files[0];
    this.preview();
  }

  private preview(): void {
    // Show preview 
    var mimeType = this.fileData.type;
    if (mimeType.match(/image\/*/) == null) {
      return;
    }

    var reader = new FileReader();
    reader.readAsDataURL(this.fileData);
    reader.onload = (_event) => {
      this.previewUrl = reader.result;
    }
  }

  public cancel(): void {
    this.closeForm();
  }

  public onLoadFile(): void {

    const formData = new FormData();
    formData.append('file', this.fileData);

    console.log('fileData : ', this.fileData);
    console.log('formData : ', formData);

    // this.httpClient.post('url/to/your/api', formData)
    //   .subscribe(res => {
    //     console.log(res);
    //     this.uploadedFilePath = res.data.filePath;
    //     alert('SUCCESS !!');
    //   })

    // Close form
    this.closeForm();
  }

  private closeForm(): void {
    this.closeComponentEmitter.emit(false);
  }
}
