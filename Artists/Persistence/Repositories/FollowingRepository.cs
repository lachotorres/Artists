using Artists.Core.Models;
using Artists.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Artists.Persistence.Repositories
{

    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;


        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public Following GetFollowing(string userId, string artistId)
        {
            return _context.Followings
                    .SingleOrDefault(f => f.FolloweeId == artistId && f.FollowerId == userId);
        }

        public IEnumerable <ApplicationUser> GetFollowees(string userId)
        {
            return _context.Followings
                .Where(f => f.FollowerId == userId)
                .Select(f => f.Followee)
                .ToList();
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }

        public void Remove(Following following)
        {
            _context.Followings.Remove(following);

        }

    }
}