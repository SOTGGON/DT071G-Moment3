namespace Guestbook
{
    public class GuestbookEntry
    {
        /*
        public string Owner { get; set; } // Undvika "Non-nullable property 'Guest' must contain a non-null value when exiting constructor"
        public string Message { get; set; } // Undvika "Non-nullable property 'Message' must contain a non-null value when exiting constructor"
        */
        private string guest =""; 
        private string message =""; 

        public string Guest { 
            get {return guest;}
            set {guest = value;} 
        }

        public string Message { 
            get {return message;}
            set {message = value;} 
        }
    }
}
