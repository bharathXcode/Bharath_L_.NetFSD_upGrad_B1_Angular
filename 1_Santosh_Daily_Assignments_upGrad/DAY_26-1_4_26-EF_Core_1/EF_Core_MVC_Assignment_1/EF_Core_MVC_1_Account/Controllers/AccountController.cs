using Microsoft.AspNetCore.Mvc;
using EF_Core_MVC_1_Account.Entities;
using EF_Core_MVC_1_Account.Repository;
using System;
using System.Threading.Tasks;

namespace EF_Core_MVC_1_Account.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepo _accountRepo;

        public AccountController(IAccountRepo accountRepo)
        {
            _accountRepo = accountRepo;
        }

        // GET: Account
        public async Task<IActionResult> Index()
        {
            var accounts = await _accountRepo.GetAllAccounts();
            return View(accounts);
        }

        // GET: Account/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var account = await _accountRepo.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // GET: Account/Create
        public IActionResult Create()
        {
            var account = new Account
            {
                CreateDate = DateTime.Now,
                Balance = 0
            };
            return View(account);
        }

        // POST: Account/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AccountId,AccountType,Customer,Balance,Brach,CreateDate")] Account account)
        {
            if (ModelState.IsValid)
            {
                await _accountRepo.AddAccount(account);
                TempData["Success"] = "Account created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var account = await _accountRepo.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Account/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,AccountType,Customer,Balance,Brach,CreateDate")] Account account)
        {
            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _accountRepo.UpdateAccount(account);
                    TempData["Success"] = "Account updated successfully!";
                }
                catch (Exception)
                {
                    if (!_accountRepo.AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Account/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var account = await _accountRepo.GetAccountById(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Account/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _accountRepo.DeleteAccount(id);
            if (result)
            {
                TempData["Success"] = "Account deleted successfully!";
            }
            else
            {
                TempData["Error"] = "Account not found!";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
