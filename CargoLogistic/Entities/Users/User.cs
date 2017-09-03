using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CargoLogistic.Domain.Events;


namespace CargoLogistic.Domain.Entities.Users
{
    public class User
    {
        public virtual OwnerShipType OwnershipType { get;  set; } 
        public virtual ActivityProfile ActivityProfile { get;  set; }
       
       
        
        private readonly List<UserMessageBox> BoxMessages = new List<UserMessageBox>();

        public User(string name, OwnerShipType ownershiptype, ActivityProfile acitvityProfile, Person contactPerson,
            Country country, City city, Location location, string email)
        {
            OwnershipType = ownershiptype;
            ActivityProfile = acitvityProfile;
          
        }

        public User()
        {
            
        }
        
        #region Event


        public void RegisterToEvent(Post post) // method to subscribe to event : post change price
        {
            post.PostPriceChanged += InboxMessage;
        }
        
        public void RegisterToEventWeakMethod(Post post) 
        {
            WeakEventManager<Post, PostPriceChangedEventArgs>.AddHandler(post, "PostPriceChanged", InboxMessage);
        }

        public void UnregisterToEvent(Post post)
        {
            post.PostPriceChanged -= InboxMessage;
        }

        public void UnregisterToEventWeakMethod(Post post)
        {
            WeakEventManager<Post, PostPriceChangedEventArgs>.RemoveHandler(post, "PostPriceChanged", InboxMessage);
        }

      
        public void InboxMessage(object sender, PostPriceChangedEventArgs p)
        {
            string content = string.Format("Post ID: {0} price has changed. The last Price was {1}. \n" +
                                           "   Now new Price is {2}. Good Offer!!!", p.ID, p.LastPrice, p.NewPrice) ;
            BoxMessages.Add(new UserMessageBox("System", "Post price changed!!!", content));
            Console.WriteLine("Add new message to " + ToString() + "\'s UserMessageBox: ");
            Console.WriteLine("   Content: " + content);
            Console.WriteLine();
        }
        #endregion
        
    }
}
