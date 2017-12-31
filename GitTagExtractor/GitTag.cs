using System;

namespace GitTagExtractor
{
    class GitTag
    {
        string app, friendlyName, canonicalName;
        string commitSHA;
        string annotationSHA, annotationMessage, annotationTaggerName, annotationTaggerEmail;
        string commitAuthorName, commitAuthorEmail, commitCommitterName, commitCommitterEmail, commitMessage;
        DateTimeOffset? annotationDate, commitCommitterDate, commitAuthorDate;

        public string App { get => app; set => app = value; }
        public string FriendlyName { get => friendlyName; set => friendlyName = value; }
        public string CanonicalName { get => canonicalName; set => canonicalName = value; }
        public string CommitSHA { get => commitSHA; set => commitSHA = value; }
        public string AnnotationSHA { get => annotationSHA; set => annotationSHA = value; }
        public string AnnotationMessage { get => annotationMessage; set => annotationMessage = value; }
        public string AnnotationTaggerName { get => annotationTaggerName; set => annotationTaggerName = value; }
        public string AnnotationTaggerEmail { get => annotationTaggerEmail; set => annotationTaggerEmail = value; }
        public string CommitAuthorName { get => commitAuthorName; set => commitAuthorName = value; }
        public string CommitAuthorEmail { get => commitAuthorEmail; set => commitAuthorEmail = value; }
        public string CommitCommitterName { get => commitCommitterName; set => commitCommitterName = value; }
        public string CommitCommitterEmail { get => commitCommitterEmail; set => commitCommitterEmail = value; }
        public string CommitMessage { get => commitMessage; set => commitMessage = value; }
        public DateTimeOffset? AnnotationDate { get => annotationDate; set => annotationDate = value; }
        public DateTimeOffset? CommitCommitterDate { get => commitCommitterDate; set => commitCommitterDate = value; }
        public DateTimeOffset? CommitAuthorDate { get => commitAuthorDate; set => commitAuthorDate = value; }
    }
}
