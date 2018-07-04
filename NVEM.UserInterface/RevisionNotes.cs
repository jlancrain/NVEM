
using System.Collections.Generic;

namespace NVEM.UserInterface
{
    public static class RevisionNotes
    {
        public static List<string> GetRevNotes()
        {
            var notes = new List<string>();

            notes.Add("");
            notes.Add("JUL 1, 2018 - V1.1.0.0");
            notes.Add("- JRL - Initial Release");

            return notes;
        }
    }
}
