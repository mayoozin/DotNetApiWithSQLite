using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteWithConsoleApp.Queries
{
    public class SQLiteQuery
    {
        public static string CreateBlogTable =
     @"CREATE TABLE IF NOT EXISTS Tbl_Blog 
    (BlogId TEXT NOT NULL, 
    BlogTitle TEXT NOT NULL, 
    BlogAuthor TEXT NOT NULL, 
    BlogContent TEXT NOT NULL)";


        public static string Insert =
       @"CREATE TABLE IF NOT EXISTS Tbl_Blog 
    (BlogId TEXT NOT NULL, 
    BlogTitle TEXT NOT NULL, 
    BlogAuthor TEXT NOT NULL, 
    BlogContent TEXT NOT NULL)";

        public static string GetAll = @"SELECT * FROM Tbl_Blog";

        public static string Update = @"UPDATE Tbl_Blog SET 
                                            BlogTitle = @BlogTitle,
                                            BlogAuthor = @BlogAuthor,
                                            BlogContent = @BlogContent 
                                            WHERE BlogId = @BlogId";

        public static string Delete = @"DELETE FROM Tbl_Blog WHERE BlogId = @BlogId";

        public static string GetDataById = @"SELECT * FROM Tbl_BLog WHERE BlogId = @BlogId";
    };
}
