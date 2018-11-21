using Logger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using Logger.Common.Configuration;
using Logger.Common;

namespace Logger.CustomLog.Strategies
{
    public class TextLogStrategy : ILogStrategy
    {
        private readonly string fullPath;
        private readonly long maxSize;

        private static ReaderWriterLock rwl = new ReaderWriterLock();

        public TextLogStrategy()
        {
            var settings = LogSettings.GetSettings().TextLog;
            this.fullPath = settings.Path;
            this.maxSize = ConvertMaxSizeInBytes(settings.MaxSize);
            var path = Path.GetDirectoryName(fullPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public TextLogStrategy(string fullPath, string maxSize)
        {
            this.fullPath = fullPath;
            this.maxSize = ConvertMaxSizeInBytes(maxSize);
        }

        private long ConvertMaxSizeInBytes(string maxSize)
        {
            long maxSizeInBytes = 0;
            const int ByteConversion = 1024;
            const string Kilobytes = "KB";
            const string Megabytes = "MB";
            const string Bytes = "";

            string unit = String.Empty;
            var sizeUnitPosition = maxSize.LastIndexOf(" ");
            if(sizeUnitPosition > -1)
            {
                unit = maxSize.Substring(sizeUnitPosition).Trim().ToUpper();
            }

            var size = maxSize.Substring(0, sizeUnitPosition).Trim();

            switch (unit)
            {
                case Bytes:
                    maxSizeInBytes = Int64.Parse(size);
                    break;
                case Kilobytes:
                    maxSizeInBytes = Int64.Parse(size) * ByteConversion;
                    break;
                case Megabytes:
                    maxSizeInBytes = Int64.Parse(size) * Convert.ToInt64(Math.Pow(ByteConversion, 2));
                    break;
                default:
                    throw new ArgumentException("Invalid file unit for file max size");
            }

            return maxSizeInBytes;
        }

        public void LogMessage(string message, LogLevel level)
        {
            const string MessagePattern = "{0} - [{1}] - {2}\n";
            try
            {
                rwl.AcquireWriterLock(-1);
                ValidateCurrentSize();
                File.AppendAllText(fullPath, String.Format(MessagePattern, DateTime.Now.ToString(), level.GetDescription(), message));
            }
            catch(ApplicationException)
            {
            }
            finally
            {
                rwl.ReleaseWriterLock();
            }
        }

        private void ValidateCurrentSize()
        {
            FileInfo fi = new FileInfo(fullPath);            
            if (fi.Exists && fi.Length >= maxSize)
            {
                string newPath = Path.Combine(fi.DirectoryName, Path.GetFileNameWithoutExtension(fullPath) + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
                File.Move(fullPath, newPath);
            }
        }
    }
}
