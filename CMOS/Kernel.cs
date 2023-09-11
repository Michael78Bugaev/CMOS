using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace CMOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs;
        public string currentdirectory = @"0:\";

        protected override void BeforeRun()
        {
            fs = new Cosmos.System.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);

        }

        protected override void Run()
        {

            Console.Write(currentdirectory + ">");
            var input = Console.ReadLine();
            if (input.Substring(0, 3) == "cd ")
            {
                var cddir = input.Substring(3);
                if (Directory.Exists(cddir))
                {
                    cddir = input.Substring(3);
                }
                else
                {
                    Console.WriteLine("Error: Directory not found");
                }
                
            }
            if (input.Substring(0, 4) == "dir ")
            {
                string dircur = input.Substring(4);
                if (Directory.Exists(dircur))
                {
                    try
                    {
                        var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(dircur);
                        foreach (var directoryEntry in directory_list)
                        {
                            try
                            {
                                var entry_type = directoryEntry.mEntryType;
                                if (entry_type == Sys.FileSystem.Listing.DirectoryEntryTypeEnum.File)
                                {

                                    Console.WriteLine("<FILE> " + directoryEntry.mName);

                                }
                                if (entry_type == Sys.FileSystem.Listing.DirectoryEntryTypeEnum.Directory)
                                {

                                    Console.WriteLine("<DIR>  " + directoryEntry.mName);


                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error: Directory not found");
                                Console.WriteLine(e.ToString());
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());

                    }
                }
                else
                {
                    Console.WriteLine("Error: Directory is not exists!");
                }
            if (input == "dir")
            {
                try
                {
                    var directory_list = Sys.FileSystem.VFS.VFSManager.GetDirectoryListing(currentdirectory);
                    foreach (var directoryEntry in directory_list)
                    {
                        try
                        {
                            var entry_type = directoryEntry.mEntryType;
                            if (entry_type == Sys.FileSystem.Listing.DirectoryEntryTypeEnum.File)
                            {
                                
                                Console.WriteLine("<FILE> " + directoryEntry.mName);
                                
                            }
                            if (entry_type == Sys.FileSystem.Listing.DirectoryEntryTypeEnum.Directory)
                            {
                                
                                Console.WriteLine("<DIR>  " + directoryEntry.mName);
                                
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: Directory not found");
                            Console.WriteLine(e.ToString());
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    
                }
                
            }
            }
        }
    }
}
