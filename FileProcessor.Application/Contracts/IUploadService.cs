using System;

namespace FileProcessor.Application.Contracts
{
    public interface IUploadService
    {
        Tuple<string, long> Upload(byte[] fileContent);
    }
}
