namespace DatingApp.API.Models
{
    public class Like
    {
        // Who is liking
        public int LikerId { get; set; }
        public User Liker { get; set; }
        
        // who is being Liked
        public int LikeeId { get; set; }
        public User Likee { get; set; }
    }
}