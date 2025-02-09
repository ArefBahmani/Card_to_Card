﻿using CardBankTransaction_HW_15.Entities;

namespace CardBankTransaction_HW_15.InterFaceRepository
{
    public interface ICardRepository
    {
        bool IsValidPassword(string cardNumber, string password);
        void WithDrow(string cardNumber, float amount);
        void Diposit(string cardNumber, float amount);
        void SetWrongPassword(string cardNumber);
        int GetWrongPasswordTrys(string cardNumber);
        bool IsActiveCard(string cardNumber);
        Card GetCardBy(string cardNumber);
        public void Changepassword(string cardNumber,string oldpassword, string newpassword);
        public float GetBalance(string cardNumber);
        public void SaveChanges();
       


    }
}
