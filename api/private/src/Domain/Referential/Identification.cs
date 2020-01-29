using System;
using System.Security.Cryptography;
using System.Text;

namespace Domain.Referential
{
    public class Identification : IDisposable
    {
        private readonly MD5 md5;

        public Identification()
        {
            // use MD5 algorithm to build 'unique' 16 byte arrays from strings
            md5 = MD5.Create();
        }

        internal Guid NewTechnicalId(string functionalKeyUtf8)
        {
            var buffer = Encoding.UTF8.GetBytes(functionalKeyUtf8);
            var hash = md5.ComputeHash(buffer);
            return new Guid(hash);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    md5.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
