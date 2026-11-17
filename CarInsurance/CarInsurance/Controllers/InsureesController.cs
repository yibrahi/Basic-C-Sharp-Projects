
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarInsurance.Models;
using CarInsurance.Data;

public class InsureesController : Controller
{
    private readonly CarInsuranceContext _context;

    public InsureesController(CarInsuranceContext context)
    {
        _context = context;
    }

    // GET: INSUREES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Insurees.ToListAsync());
    }

    // GET: INSUREES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // GET: INSUREES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: INSUREES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
    [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")]
    Insuree insuree)
    {
        // Check that all submitted information is valid.
        if (ModelState.IsValid)
        {
            // Calculate the insurance quote automatically.
            insuree.Quote = CalculateQuote(insuree);

            // Add the insuree to the database.
            _context.Add(insuree);

            // Save the changes.
            await _context.SaveChangesAsync();

            // Return the user to the Index page.
            return RedirectToAction(nameof(Index));
        }

        return View(insuree);
    }

    private decimal CalculateQuote(Insuree insuree)
    {
        // Every customer starts with a base quote of $50.
        decimal quote = 50m;

        // Get today's date.
        DateTime today = DateTime.Today;

        // Calculate the customer's age.
        int age = today.Year - insuree.DateOfBirth.Year;

        // Correct the age if the customer has not had their birthday yet this year.
        if (insuree.DateOfBirth.Date > today.AddYears(-age))
        {
            age--;
        }

        // Customers age 18 or younger receive an additional $100 charge.
        if (age <= 18)
        {
            quote += 100m;
        }

        // Customers between 19 and 25 receive an additional $50 charge.
        else if (age <= 25)
        {
            quote += 50m;
        }

        // Customers age 26 or older receive an additional $25 charge.
        else
        {
            quote += 25m;
        }

        // Cars made before 2000 add $25.
        if (insuree.CarYear < 2000)
        {
            quote += 25m;
        }

        // Cars made after 2015 add $25.
        if (insuree.CarYear > 2015)
        {
            quote += 25m;
        }

        // Check whether the car is a Porsche.
        if (string.Equals(
            insuree.CarMake,
            "Porsche",
            StringComparison.OrdinalIgnoreCase))
        {
            // All Porsche vehicles add $25.
            quote += 25m;

            // A Porsche 911 Carrera adds another $25.
            if (string.Equals(
                insuree.CarModel,
                "911 Carrera",
                StringComparison.OrdinalIgnoreCase))
            {
                quote += 25m;
            }
        }

        // Add $10 for every speeding ticket.
        quote += insuree.SpeedingTickets * 10m;

        // A DUI increases the current quote by 25%.
        if (insuree.DUI)
        {
            quote *= 1.25m;
        }

        // Full coverage increases the current quote by 50%.
        if (insuree.CoverageType)
        {
            quote *= 1.50m;
        }

        // Round the final quote to two decimal places.
        return Math.Round(quote, 2);
    }

    // GET: INSUREES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees.FindAsync(id);
        if (insuree == null)
        {
            return NotFound();
        }
        return View(insuree);
    }

    // POST: INSUREES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
    {
        if (id != insuree.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                insuree.Quote = CalculateQuote(insuree);
                _context.Update(insuree);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InsureeExists(insuree.Id))
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
        return View(insuree);
    }

    // GET: INSUREES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var insuree = await _context.Insurees
            .FirstOrDefaultAsync(m => m.Id == id);
        if (insuree == null)
        {
            return NotFound();
        }

        return View(insuree);
    }

    // POST: INSUREES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var insuree = await _context.Insurees.FindAsync(id);
        if (insuree != null)
        {
            _context.Insurees.Remove(insuree);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool InsureeExists(int? id)
    {
        return _context.Insurees.Any(e => e.Id == id);
    }

    // Displays insurance quotes for the administrator.
    public async Task<IActionResult> Admin()
    {
        // Retrieve all insurees from the database.
        var insurees = await _context.Insurees.ToListAsync();

        // Send the insurees to the Admin view.
        return View(insurees);
    }
}
