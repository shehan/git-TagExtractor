using LibGit2Sharp;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace GitTagExtractor
{
    public partial class Form1 : Form
    {
        Database database;
        List<GitTag> gitTagList;
        string inputFile, destinationPath;
        Hashtable apps = new Hashtable();
        FileInfo errorFile = new FileInfo("error_item.txt");
        FileInfo errorFile2 = new FileInfo("error_other.txt");
        bool saveFiles, savePatchText;
        List<string> includedFiles = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }



        private void DoWork()
        {
            UpdateStatus("Initialzing Database");
            database = new Database();

            UpdateStatus("Reading Input File");
            ReadInputFile();

            foreach (DictionaryEntry entry in apps)
            {
                UpdateStatus($"Processing App: {entry.Key.ToString()}");
                GetTagDetails(entry.Key.ToString(), entry.Value.ToString());
            }

            MessageBox.Show("Completed!");
        }

        private void ReadInputFile()
        {
            string[] fields;

            using (TextFieldParser parser = new TextFieldParser(inputFile))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                parser.HasFieldsEnclosedInQuotes = true;
                while (!parser.EndOfData)
                {
                    fields = parser.ReadFields();
                    apps.Add(fields[0], fields[1]);
                }
            }
        }


        private void GetTagDetails(string app, string repoPath)
        {
            try
            {

                gitTagList = new List<GitTag>();

                using (var repo = new Repository(repoPath))
                {
                    var tags = repo.Tags;
                    int count = 0;
                    GitTag gitTag;
                    var sw = Stopwatch.StartNew();
                    foreach (Tag tagItem in repo.Tags)
                    {
                        try
                        {
                            Console.WriteLine("Enumerating  tag: {0}ms", sw.ElapsedMilliseconds);
                            sw.Restart();

                            gitTag = new GitTag();
                            gitTag.AnnotationDate = tagItem.IsAnnotated ? tagItem.Annotation.Tagger.When : (DateTimeOffset?)null;
                            gitTag.AnnotationMessage = tagItem.IsAnnotated ? tagItem.Annotation.Message : string.Empty;
                            gitTag.AnnotationSHA = tagItem.IsAnnotated ? tagItem.Annotation.Sha : string.Empty;
                            gitTag.AnnotationTaggerEmail = tagItem.IsAnnotated ? tagItem.Annotation.Tagger.Email : string.Empty;
                            gitTag.AnnotationTaggerName = tagItem.IsAnnotated ? tagItem.Annotation.Tagger.Name : string.Empty;
                            gitTag.App = app;
                            gitTag.CanonicalName = tagItem.CanonicalName;
                            gitTag.CommitAuthorDate = ((Commit)tagItem.PeeledTarget).Author.When;
                            gitTag.CommitAuthorEmail = ((Commit)tagItem.PeeledTarget).Author.Email;
                            gitTag.CommitAuthorName = ((Commit)tagItem.PeeledTarget).Author.Name;
                            gitTag.CommitCommitterDate = ((Commit)tagItem.PeeledTarget).Committer.When;
                            gitTag.CommitCommitterEmail = ((Commit)tagItem.PeeledTarget).Committer.Email;
                            gitTag.CommitCommitterName = ((Commit)tagItem.PeeledTarget).Committer.Name;
                            gitTag.CommitMessage = ((Commit)tagItem.PeeledTarget).Message;
                            gitTag.CommitSHA = ((Commit)tagItem.PeeledTarget).Sha;
                            gitTag.FriendlyName = tagItem.FriendlyName;

                            gitTagList.Add(gitTag);
                        }
                        catch (Exception error)
                        {
                            File.AppendAllText(errorFile.FullName, $"{app},{tagItem.CanonicalName};{error.Message}{Environment.NewLine}");
                            continue;
                        }

                        count++;
                    }
                    Console.WriteLine("Analyzed tags:{0}", count);
                }

                database.BatchInsertPatch(gitTagList);

            }
            catch (Exception error)
            {
                UpdateStatus($"{error.ToString()}");
                return;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxInput.Text))
            {
                MessageBox.Show("Input File - Required!");
                return;
            }

            //saveFiles = checkBoxFiles.Checked;
            //if (saveFiles)
            //{
            //    if (!Directory.Exists(textBoxDestination.Text))
            //    {
            //        MessageBox.Show("Invalid Destination Directory");
            //        return;
            //    }
            //}

            //if (!string.IsNullOrEmpty(textBoxFileTypes.Text))
            //{
            //    includedFiles = textBoxFileTypes.Text.Split(',').ToList();
            //}

            inputFile = textBoxInput.Text;
            //destinationPath = textBoxDestination.Text;

            UpdateStatus("Process Started");
            buttonStart.Enabled = false;
            ThreadStart threadStart = new ThreadStart(DoWork);
            Thread thread = new Thread(threadStart);
            thread.Start();
        }

        private void UpdateStatus(string text)
        {
            if (this.textBoxLog.InvokeRequired)
            {
                UpdateStatusCallback callback = new UpdateStatusCallback(UpdateStatus);
                this.Invoke(callback, new object[] { text });
            }
            else
            {
                textBoxLog.AppendText($"{Environment.NewLine}{DateTime.Now.ToString()} - {text}");
            }
        }

        private void checkBoxFiles_CheckedChanged(object sender, EventArgs e)
        {
            textBoxDestination.Enabled = checkBoxFiles.Checked;
            textBoxFileTypes.Enabled = checkBoxFiles.Checked;
        }

        delegate void UpdateStatusCallback(string text);
    }
}
