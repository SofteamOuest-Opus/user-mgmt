import { Component, Output, EventEmitter } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent {

  @Output() closeComponentEmitter = new EventEmitter<boolean>();

  public showButtons: boolean = false;
  public showErrMessage: boolean = false;
  public fileData: File = null;
  public previewUrl: any;
  public uploadedFilePath: string;

  constructor(
    private httpClient: HttpClient,

  ) { }


  public fileProgress(fileInput: any): void {
    this.showErrMessage = false;
    this.fileData = <File>fileInput.target.files[0];

    // Verify file type
    let validFileType: boolean = false;
    validFileType = this.verifyFileType(this.fileData);

    // show Preview
    if (validFileType)
      this.preview(this.fileData);
    else
      this.showErrorMessage();
  }

  private preview(fileData: File): void {
    this.showButtons = true;
    let reader = new FileReader();
    reader.readAsDataURL(fileData);
    reader.onload = () => {
      this.previewUrl = reader.result;
    }
  }

  public cancel(): void {
    this.closeForm();
  }

  public onLoadFile(fileData: File): void {

    const formData = new FormData();
    formData.append('file', fileData);

    console.log('fileData : ', fileData);
    console.log('formData : ', formData);

    // --- TODO POST TO API

    // this.httpClient.post('url/to/your/api', formData)
    //   .subscribe(res => {
    //     this.uploadedFilePath = res.data.filePath;
    //   })

    this.closeForm();
  }

  private verifyFileType(fileData: File): boolean {
    let mimeType = fileData.type;
    return (mimeType.match(/image\/*/) !== null);
  }

  private showErrorMessage(): void {
    this.showErrMessage = true;
  }

  private closeForm(): void {
    this.closeComponentEmitter.emit(false);
  }
}
