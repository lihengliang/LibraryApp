using System;
using System.Collections.Generic;
using System.Linq;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryServices
{
    public class PatronService : IPatron
    {
        private LibraryContext _context;

        public PatronService(LibraryContext context)
        {
            _context = context;
        }

        public void Add(Patron newPatron)
        {
            _context.Add(newPatron);
            _context.SaveChanges();
        }

        public Patron Get(int id)
        {
            return GetAll()
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons
                .Include(a => a.LibraryCard)
                .Include(a => a.HomeLibraryBranch);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId)
        {
            var cardId = Get(patronId).LibraryCard.Id;

            return _context.CheckoutHistories
                .Include(c => c.LibraryCard)
                .Include(c=> c.LibraryAsset)
                .Where(c => c.LibraryCard.Id == cardId)
                .OrderByDescending(c => c.CheckedOut);
        }

        public IEnumerable<Checkouts> GetCheckouts(int patronId)
        {
            var cardId = Get(patronId).LibraryCard.Id;

            return _context.Checkouts
                .Include(c => c.LibraryCard)
                .Include(c => c.LibraryAsset)
                .Where(c => c.LibraryCard.Id == cardId);
        }

        public IEnumerable<Holds> GetHolds(int patronId)
        {
            var cardId = Get(patronId).LibraryCard.Id;

            return _context.Holds
                .Include(c => c.LibraryCard)
                .Include(c => c.LibraryAsset)
                .Where(c => c.LibraryCard.Id == cardId)
                .OrderByDescending(h=> h.HoldPlaced);
        }
    }
}
