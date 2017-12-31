using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace GitTagExtractor
{
    class Database
    {
        private string filePath, connectionString;

        public Database()
        {
            filePath = $"TagDB_{DateTime.Now.Ticks}.sqlite";
            connectionString = $"Data Source={filePath};Version=3;";
            CreateDB();
            CreateTable();
        }

        private void CreateDB()
        {
            SQLiteConnection.CreateFile(filePath);
        }

        private void CreateTable()
        {
            string sql = "CREATE TABLE IF NOT EXISTS GIT_TAG(" +
            "App TEXT," +
            "FriendlyName TEXT, " +
            "CanonicalName TEXT, " +
            "CommitSHA TEXT, " +
            "AnnotationSHA TEXT, " +
            "AnnotationMessage TEXT, " +
            "AnnotationTaggerName TEXT, " +
            "AnnotationTaggerEmail TEXT, " +
            "CommitAuthorName TEXT, " +
            "CommitAuthorEmail TEXT, " +
            "CommitCommitterName TEXT, " +
            "CommitCommitterEmail TEXT, " +
            "CommitMessage TEXT, " +
            "AnnotationDate_TICKS REAL, " +
            "AnnotationDate_TEXT TEXT, " +
            "CommitCommitterDate_TICKS REAL, " +
            "CommitCommitterDate_TEXT TEXT, " +
            "CommitAuthorDate_TICKS REAL, " +
            "CommitAuthorDate_TEXT TEXT" +
            ");";

            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand command = new SQLiteCommand(dbConnection))
                {
                    using (var transaction = dbConnection.BeginTransaction())
                    {
                        command.CommandText = sql;
                        command.ExecuteNonQuery();
                        transaction.Commit();
                    }
                }

                dbConnection.Close();
            }
        }

        public void BatchInsertPatch(List<GitTag> tagList)
        {
            string query = "INSERT INTO GIT_TAG " +
                                "(App, FriendlyName, CanonicalName, CommitSHA, AnnotationSHA, AnnotationMessage, AnnotationTaggerName, AnnotationTaggerEmail,CommitAuthorName,CommitAuthorEmail,CommitCommitterName,CommitCommitterEmail,CommitMessage,AnnotationDate_TICKS,AnnotationDate_TEXT,CommitCommitterDate_TICKS,CommitCommitterDate_TEXT,CommitAuthorDate_TICKS,CommitAuthorDate_TEXT) " +
                                "VALUES (@App, @FriendlyName, @CanonicalName, @CommitSHA, @AnnotationSHA, @AnnotationMessage, @AnnotationTaggerName, @AnnotationTaggerEmail, @CommitAuthorName, @CommitAuthorEmail, @CommitCommitterName, @CommitCommitterEmail,@CommitMessage,@AnnotationDate_TICKS,@AnnotationDate_TEXT,@CommitCommitterDate_TICKS,@CommitCommitterDate_TEXT,@CommitAuthorDate_TICKS,@CommitAuthorDate_TEXT);";

            using (var dbConnection = new SQLiteConnection(connectionString))
            {
                dbConnection.Open();
                using (SQLiteCommand command = new SQLiteCommand(dbConnection))
                {
                    using (var transaction = dbConnection.BeginTransaction())
                    {
                        foreach (var tag in tagList)
                        {
                            command.Parameters.AddWithValue("@App", tag.App);

                            command.Parameters.AddWithValue("@FriendlyName", tag.FriendlyName);
                            command.Parameters.AddWithValue("@CanonicalName", tag.CanonicalName);
                            command.Parameters.AddWithValue("@CommitSHA", tag.CommitSHA);
                            command.Parameters.AddWithValue("@AnnotationSHA", tag.AnnotationSHA);
                            command.Parameters.AddWithValue("@AnnotationMessage", tag.AnnotationMessage);
                            command.Parameters.AddWithValue("@AnnotationTaggerName", tag.AnnotationTaggerName);
                            command.Parameters.AddWithValue("@AnnotationTaggerEmail", tag.AnnotationTaggerEmail);
                            command.Parameters.AddWithValue("@CommitAuthorName", tag.CommitAuthorName);
                            command.Parameters.AddWithValue("@CommitAuthorEmail", tag.CommitAuthorEmail);
                            command.Parameters.AddWithValue("@CommitCommitterName", tag.CommitCommitterName);
                            command.Parameters.AddWithValue("@CommitCommitterEmail", tag.CommitCommitterEmail);
                            command.Parameters.AddWithValue("@CommitMessage", tag.CommitMessage);
                            command.Parameters.AddWithValue("@AnnotationDate_TICKS", tag.AnnotationDate.HasValue?tag.AnnotationDate.Value.Ticks:(long?)null);
                            command.Parameters.AddWithValue("@AnnotationDate_TEXT", tag.AnnotationDate.HasValue ? tag.AnnotationDate.Value.ToString() : string.Empty);
                            command.Parameters.AddWithValue("@CommitCommitterDate_TICKS", tag.CommitCommitterDate.HasValue ? tag.CommitCommitterDate.Value.Ticks : (long?)null);
                            command.Parameters.AddWithValue("@CommitCommitterDate_TEXT", tag.CommitCommitterDate.HasValue ? tag.CommitCommitterDate.Value.ToString() : string.Empty);
                            command.Parameters.AddWithValue("@CommitAuthorDate_TICKS", tag.CommitAuthorDate.HasValue ? tag.CommitAuthorDate.Value.Ticks : (long?)null);
                            command.Parameters.AddWithValue("@CommitAuthorDate_TEXT", tag.CommitAuthorDate.HasValue ? tag.CommitAuthorDate.Value.ToString() : string.Empty);

                            command.CommandText = query;
                            command.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                }

                dbConnection.Close();
            }
        }
    }
}
