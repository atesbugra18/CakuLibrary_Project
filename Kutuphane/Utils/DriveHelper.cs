using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using File = Google.Apis.Drive.v3.Data.File;

namespace Kutuphane.Utils
{
    public static class DriveUploadHelper
    {
        private static readonly string OnKapakKlasorId = "https://drive.google.com/drive/folders/1_kY7fr3EKL--mS0x-N6H3DdqLCZiXvpI?usp=drive_link";
        private static readonly string ArkaKapakKlasorId = "https://drive.google.com/drive/folders/1ijZms0lzWG9z2FwC09YyvsASCE_vf7Wd?usp=drive_link";
        public static class GoogleDriveServiceFactory
        {
            private static readonly string[] Scopes = { DriveService.Scope.Drive };
            private static readonly string ApplicationName = "Kutuphane";
            public static DriveService GetDriveService()
            {
                UserCredential credential;
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    var credPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), ".credentials/drive-dotnet-quickstart.json");
                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }
                var driveService = new DriveService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });
                return driveService;
            }
        }
        public static async Task<string> UploadImageToDriveAsync(string filePath, bool isOnKapak)
        {
            string targetFolderId = isOnKapak ? OnKapakKlasorId : ArkaKapakKlasorId;
            var driveService = GoogleDriveServiceFactory.GetDriveService();
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = Path.GetFileName(filePath),
                Parents = new List<string> { targetFolderId }
            };
            FilesResource.CreateMediaUpload request;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                request = driveService.Files.Create(fileMetadata, stream, "image/jpeg");
                request.Fields = "id";
                await request.UploadAsync();
            }
            var file = request.ResponseBody;
            return file.Id;
        }
        public static async Task SetPublicPermissionAsync(string fileId)
        {
            var driveService = GoogleDriveServiceFactory.GetDriveService();
            var permission = new Google.Apis.Drive.v3.Data.Permission()
            {
                Role = "reader",
                Type = "anyone"
            };

            await driveService.Permissions.Create(permission, fileId).ExecuteAsync();
        }
    }

}

