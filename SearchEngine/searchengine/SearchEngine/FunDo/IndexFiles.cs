using System;
using Lucene.Net.Index;
using StandardAnalyzer = Lucene.Net.Analysis.Standard.StandardAnalyzer;
using IndexWriter = Lucene.Net.Index.IndexWriter;
using Document = Lucene.Net.Documents.Document;
using Field = Lucene.Net.Documents.Field;
using DateTools = Lucene.Net.Documents.DateTools;


namespace FunDo
{
    class IndexFiles
    {
        internal static readonly System.IO.FileInfo INDEX_DIR =
            new System.IO.FileInfo("index");

        [STAThread]
        public static void Main(System.String[] args)
        {
            System.String usage = typeof(IndexFiles) + " <root_directory>";
            if (args.Length == 0)
            {
                System.Console.Error.WriteLine("Usage: " + usage);
                System.Environment.Exit(1);
            }

            // Check whether the "index" directory exists.
            // If not, create it; otherwise, exit program.
            bool tmpBool = System.IO.Directory.Exists(INDEX_DIR.FullName);
            if (tmpBool)
            {
                System.Console.Out.WriteLine("Cannot save index to '" +
                    INDEX_DIR + "' directory, please delete it first");
                System.Environment.Exit(1);
            }

            System.IO.FileInfo docDir = new System.IO.FileInfo(args[0]);
            tmpBool = System.IO.Directory.Exists(docDir.FullName);
            if (!tmpBool)
            {
                System.Console.Out.WriteLine("Document directory '" +
                    docDir.FullName + "' does not exist or is not readable, " +
                    "please check the path");
                System.Environment.Exit(1);
            }

            System.DateTime start = System.DateTime.Now;
            try
            {
                IndexWriter writer = new IndexWriter(INDEX_DIR, new StandardAnalyzer(), true);
                System.Console.Out.WriteLine("Indexing to directory '" +
                                             INDEX_DIR + "'...");
                IndexDocs(writer, docDir);
                System.Console.Out.WriteLine("Optimizing...");
                writer.Optimize();
                writer.Close();

                System.DateTime end = System.DateTime.Now;
                System.Console.Out.WriteLine(end.Ticks - start.Ticks +
                                             " total milliseconds");
            }
            catch (System.IO.IOException e)
            {
                System.Console.Out.WriteLine(" caught a " + e.GetType() +
                                             "\n with message: " + e.Message);
            }
        }

        public static void IndexDocs(IndexWriter writer,
                                      System.IO.FileInfo file)
        {
            if (System.IO.Directory.Exists(file.FullName))
            {
                System.String[] files =
                    System.IO.Directory.GetFileSystemEntries(file.FullName);
                if (files != null)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        IndexDocs(writer, new System.IO.FileInfo(files[i]));
                    }
                }
            }
            else
            {
                System.Console.Out.WriteLine("adding " + file);
                writer.AddDocument(IndexDocument(file));
            }
        }

        public static Document IndexDocument(System.IO.FileInfo f)
        {
            // Make a new, empty document
            Document doc = new Document();

            // Add the path of the file as a field named "path".
            // Use a field that is indexed (i.e., searchable), but don't
            // tokenize the field into words.
            doc.Add(new Field("path", f.FullName, Field.Store.YES,
                              Field.Index.UN_TOKENIZED));

            // Add the last modified date of the file to a field named
            // "modified". Use a field that is indexed (i.e., searchable),
            // but don't tokenize the field into words.
            doc.Add(new Field("modified",
                              DateTools.TimeToString(f.LastWriteTime.Ticks,
                              DateTools.Resolution.MINUTE),
                              Field.Store.YES, Field.Index.UN_TOKENIZED));

            // Add the contents of the file to a field named "contents".
            // Specify a Reader, so that the text of the file is tokenized
            // and indexed, but not stored. Note that FileReader expects
            // the file to be in the system's default encoding. If that's
            // not the case, searching for special characters will fail.
            doc.Add(new Field("contents",
                              new System.IO.StreamReader(f.FullName,
                              System.Text.Encoding.Default)));

            // Return the document
            return doc;
        }
    }
}
