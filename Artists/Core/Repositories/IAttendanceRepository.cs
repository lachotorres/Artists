using Artists.Core.Models;
using System.Collections.Generic;


namespace Artists.Core.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetFutureAttendances(string userId);
        Attendance GetAttendance(int gigId, string userId);
        void Add(Attendance attendance);
        void Remove(Attendance attendance);

    }
}
