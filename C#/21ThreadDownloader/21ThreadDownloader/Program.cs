using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace _21ThreadDownloader
{
    class Program
    {
        private static readonly int OMIT_HREF_LENGTH = 8;
        private static readonly int OMIT_FINAL_SIGN_LENGTH = OMIT_HREF_LENGTH + 1;
        private static readonly int FILENAME_ONLY_LENGTH = 12;
        private static readonly int THREAD_STRING_LENGTH = 7;
        private static readonly string SAVE_PATH = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)).FullName;

        static void Main(string[] args)
        {
            String threadNumber = args[0];
            String saveFolderName = createSaveFolderName(threadNumber);

            List<String> pictures = new List<String>();

            try
            {
                pictures = downloadThreadHTMLAndExtractPictureNames(threadNumber);
            }
            catch (WebException web)
            {
                Console.WriteLine(web.Message);
            }

            Directory.CreateDirectory(SAVE_PATH + @"\" + saveFolderName);

            try
            {
                downloadPictures(pictures, saveFolderName);
            }
            catch (WebException web)
            {
                Console.WriteLine(web.Message);
            }
            
        }

        private static string createSaveFolderName(String threadString)
        {
            if (threadString.Contains('#'))
            {
                return threadString.Substring(threadString.LastIndexOf("thread/") + THREAD_STRING_LENGTH, threadString.LastIndexOf('#') - (threadString.LastIndexOf("thread/") + THREAD_STRING_LENGTH));
            }
            else
            {
                return threadString.Substring(threadString.LastIndexOf("thread/") + THREAD_STRING_LENGTH, threadString.Length - (threadString.LastIndexOf("thread/") + THREAD_STRING_LENGTH));
            }
        }

        private static List<String> downloadThreadHTMLAndExtractPictureNames(String ThreadString)
        {
            String[] html;
            using (WebClient client = new WebClient())
            {
                html = client.DownloadString(ThreadString).Split(' ');
            }

            var pictures =
                from h in html
                where h.StartsWith("href")
                && (h.Contains(".jpg")
                || h.Contains(".png")
                || h.Contains(".gif")
                )
                select h.Substring(OMIT_HREF_LENGTH, h.Length - OMIT_FINAL_SIGN_LENGTH);

            return pictures.ToList<String>();
        }

        private static void downloadPictures(List<String> pictures, String saveFolderName)
        {
            using (WebClient client = new WebClient())
            {
                foreach (String picture in pictures)
                {
                    client.DownloadFile(@"http://" + picture, SAVE_PATH + @"\" + saveFolderName + @"\" + picture.Substring(FILENAME_ONLY_LENGTH));
                }
            }
        }
    }
}
