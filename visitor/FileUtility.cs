namespace visitor
{

    public interface IFileUtility
    {
        public long GetFileNumber(ICollection<FileInfo> files);
        public long GetFileSize(ICollection<FileInfo> files);
    }


    public class AllFileUtility : IFileUtility
    {
        void Accept(IFileVisitor fileVisitor, ICollection<FileInfo> files)
        {
            fileVisitor.Visit(this, files);
        }
        public  long GetFileNumber(ICollection<FileInfo> files)
        {
            return files.Count();
        }

        public long GetFileSize(ICollection<FileInfo> files)
        {
            return files.Select(x => x.Length).Sum();
        }
    }

    public class JPegFileUtility : IFileUtility
    {
        void Accept(IFileVisitor fileVisitor, ICollection<FileInfo> files)
        {
            fileVisitor.Visit(this,files);
        }
        public long GetFileNumber(ICollection<FileInfo> files)
        {
            return files.Where(x => x.Extension.ToLower() == "jpeg").Count();
        }

        public long GetFileSize(ICollection<FileInfo> files)
        {
            return  files.Where(x => x.Extension.ToLower() == "jpeg").Select(x => x.Length).Sum();
        }
    }

    public class PngFileUtility : IFileUtility
    {
        void Accept(IFileVisitor fileVisitor, ICollection<FileInfo> files)
        {
            fileVisitor.Visit(this, files);
        }
        public long GetFileNumber(ICollection<FileInfo> files)
        {
            return files.Where(x => x.Extension.ToLower() == "png").Count();
        }

        public long GetFileSize(ICollection<FileInfo> files)
        {
            return files.Where(x => x.Extension.ToLower() == "png").Select(x => x.Length).Sum();
        }
    }

    public interface IFileVisitor
    {
        long Visit(PngFileUtility fileUtility, ICollection<FileInfo> fileInfos);
        long Visit(AllFileUtility fileUtility, ICollection<FileInfo> fileInfos);
        long Visit(JPegFileUtility fileUtility, ICollection<FileInfo> fileInfos);
    }
    public class GetFileNumberFileVisitor : IFileVisitor 
    {
        public long Visit(PngFileUtility fileUtility, ICollection<FileInfo> fileInfos)
        {
            return fileUtility.GetFileNumber(fileInfos);
        }

        public long Visit(AllFileUtility fileUtility, ICollection<FileInfo> fileInfos)
        {
            return fileUtility.GetFileNumber(fileInfos);
        }

        public long Visit(JPegFileUtility fileUtility, ICollection<FileInfo> fileInfos)
        {
            return fileUtility.GetFileNumber(fileInfos);
        }
    }
    public class GetFileSizeVisitor  : IFileVisitor 
    {
        public long Visit(PngFileUtility fileUtility, ICollection<FileInfo> fileInfos)
        {
            return fileUtility.GetFileSize(fileInfos);
        }

        public long Visit(AllFileUtility fileUtility, ICollection<FileInfo> fileInfos)
        {
            return fileUtility.GetFileSize(fileInfos);
        }

        public long Visit(JPegFileUtility fileUtility, ICollection<FileInfo> fileInfos)
        {
            return fileUtility.GetFileSize(fileInfos);
        }
    }
}
    

