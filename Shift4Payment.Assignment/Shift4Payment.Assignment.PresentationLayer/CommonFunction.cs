using Shift4Payment.Assignment.DataModelLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;

namespace Shift4Payment.Assignment.PresentationLayer
{
    public class CommonFunction
    {
        /// <summary>
        /// gets user prifile information
        /// </summary>
        /// <returns></returns>
        public static UserModel GetProfile()
        {
            UserModel model = null;
            var profileSession = HttpContext.Current.Session["profile"];
            if (profileSession != null)
            {
                model = profileSession as UserModel;
            }
            return model;
        }
        
        //defines scope.
        public static string[] Scopes = { DriveService.Scope.Drive };
        public static string ApplicationName = "Drive API .NET Quickstart";
        
        /// <summary>
        /// creates Drive API service.
        /// </summary>
        /// <returns></returns>
        public static DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;
            using (var stream = new FileStream(HttpContext.Current.Server.MapPath("credentials.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = "DriveServiceCredential.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(HttpContext.Current.Server.MapPath(credPath), true)).Result;
            }

            //create Drive API service.
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
            return service;
        }
        
        /// <summary>
        /// get all files from Google Drive.
        /// </summary>
        /// <returns></returns>
        public static List<GoogleDriveFiles> GetDriveFiles()
        {
            DriveService service = GetService();

            // define parameters of request.
            FilesResource.ListRequest FileListRequest = service.Files.List();

            //listRequest.PageSize = 10;
            //listRequest.PageToken = 10;
            FileListRequest.Fields = "nextPageToken, files(id, name, size, version, createdTime)";

            //get file list.
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            List<GoogleDriveFiles> FileList = new List<GoogleDriveFiles>();

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    GoogleDriveFiles File = new GoogleDriveFiles
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Size = file.Size,
                        Version = file.Version,
                        CreatedTime = file.CreatedTime
                    };
                    FileList.Add(File);
                }
            }
            return FileList;
        }

       
        /// <summary>
        ///  Upload file to the Google Drive.
        /// </summary>
        /// <param name="file"></param>
        public static void FileUpload(HttpPostedFile file)
        {
            if (file != null && file.ContentLength > 0)
            {
                DriveService service = GetService();

                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/GoogleDriveFiles"),
                Path.GetFileName(file.FileName));
                file.SaveAs(path);

                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = Path.GetFileName(file.FileName);
                FileMetaData.MimeType = MimeMapping.GetMimeMapping(path);

                FilesResource.CreateMediaUpload request;

                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
            }
        }

        /// <summary>
        /// upload file to google drive
        /// </summary>
        /// <param name="fileName"></param>
        public static void FileUpload(string fileName)
        {
            if (!string.IsNullOrWhiteSpace(fileName))
            {
                DriveService service = GetService();

                string path = Path.Combine(HttpContext.Current.Server.MapPath("~/Documents"),
                     Path.GetFileName(fileName));


                var FileMetaData = new Google.Apis.Drive.v3.Data.File();
                FileMetaData.Name = Path.GetFileName(fileName);
                FileMetaData.MimeType = MimeMapping.GetMimeMapping(path);

                FilesResource.CreateMediaUpload request;

                using (var stream = new System.IO.FileStream(path, System.IO.FileMode.Open))
                {
                    request = service.Files.Create(FileMetaData, stream, FileMetaData.MimeType);
                    request.Fields = "id";
                    request.Upload();
                }
            }
        }

        
        /// <summary>
        /// Download the file from Google Drive by fileId.
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public static string DownloadGoogleFile(string fileId)
        {
            DriveService service = GetService();

            string FolderPath = System.Web.HttpContext.Current.Server.MapPath("/GoogleDriveFiles/");
            FilesResource.GetRequest request = service.Files.Get(fileId);

            string FileName = request.Execute().Name;
            string FilePath = System.IO.Path.Combine(FolderPath, FileName);

            MemoryStream stream1 = new MemoryStream();

            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            SaveStream(stream1, FilePath);
                            break;
                        }
                    case DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream1);
            return FilePath;
        }

        
        /// <summary>
        /// save file to server path
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="FilePath"></param>
        private static void SaveStream(MemoryStream stream, string FilePath)
        {
            using (System.IO.FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.WriteTo(file);
            }
        }

        
        /// <summary>
        /// Delete file from the Google drive
        /// </summary>
        /// <param name="files"></param>
        public static void DeleteFile(GoogleDriveFiles files)
        {
            DriveService service = GetService();
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");

                if (files == null)
                    throw new ArgumentNullException(files.Id);

                // Make the request.
                service.Files.Delete(files.Id).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Files.Delete failed.", ex);
            }
        }
    }
    /// <summary>
    /// Class for google drive file information
    /// </summary>
    public class GoogleDriveFiles
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }
        public long? Version { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}