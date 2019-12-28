using System;
using System.Collections.Generic;
using LibraryData.Models;

namespace LibraryData
{
    public interface ICheckout
    {
        IEnumerable<Checkouts> GetAll();
        Checkouts GetById(int checkoutId);

        void Add(Checkouts newCheckout);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);

        void PlaceHold(int assetId, int libraryCardId);

        string GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced(int id);
        Checkouts GetLatestCheckout(int id);
        IEnumerable<Holds> GetCurrentHolds(int id);
        void MarkLost(int assetId);
        void MarkFound(int assetId);
        string GetCurrentCheckoutPatron(int assetId);
        bool IsCheckedOut(int id);

    };

}
