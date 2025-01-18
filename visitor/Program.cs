
using visitor;
using System.Collections.ObjectModel;

var visitor = new GetFileNumberFileVisitor();
var visitor2 = new GetFileSizeVisitor();

var jPegFileUtility = new JPegFileUtility();
var pngFileUtility = new PngFileUtility();
var AllFileUtility = new AllFileUtility();

var res =  visitor.Visit(jPegFileUtility, new Collection<FileInfo>());
Console.WriteLine("All number of jpegfile = " + res);

var res2  =visitor2.Visit(AllFileUtility, new Collection<FileInfo>()); 
Console.WriteLine("Get size of all files = " + res2);
