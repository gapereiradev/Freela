using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freela.Infra.CloudServices.Interface
{
    public interface IFileStorageService
    {
        void UploadFile(byte[] bytes, string fileName);
    }
}