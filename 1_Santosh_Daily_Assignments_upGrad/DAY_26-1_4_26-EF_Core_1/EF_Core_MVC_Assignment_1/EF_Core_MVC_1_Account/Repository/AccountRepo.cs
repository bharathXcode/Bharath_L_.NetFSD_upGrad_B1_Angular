using Microsoft.EntityFrameworkCore;
using EF_Core_MVC_1_Account.Database;
using EF_Core_MVC_1_Account.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF_Core_MVC_1_Account.Repository
{
    public interface IAccountRepo
    {
        Task<IEnumerable<Account>> GetAllAccounts();
        Task<Account> GetAccountById(int id);
        Task<Account> AddAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int id);
        bool AccountExists(int id);
    }

    public class AccountRepo : IAccountRepo
    {
        private readonly AppDbContext _context;

        public AccountRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts()
        {
            return await _context.Accounts.OrderByDescending(a => a.CreateDate).ToListAsync();
        }

        public async Task<Account> GetAccountById(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        public async Task<Account> AddAccount(Account account)
        {
            account.CreateDate = DateTime.Now;
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<bool> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
                return false;

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }
    }
}
