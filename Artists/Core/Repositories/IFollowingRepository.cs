using Artists.Core.Models;
using System.Collections.Generic;


namespace Artists.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string artistId);
        IEnumerable<ApplicationUser> GetFollowees(string userId);
        void Add(Following following);
        void Remove(Following following);
    }
}
