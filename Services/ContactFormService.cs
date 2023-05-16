using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Services;

public class ContactFormService
{
    private readonly FormContext _formContext;

    public ContactFormService(FormContext formContext)
    {
        _formContext = formContext;
    }

    public async Task<bool> CreateAsync(ContactFormViewModel contactFormViewModel)
    {
        try
        {
            ContactEntity contactEntity = contactFormViewModel;
            _formContext.Contacts.Add(contactEntity);
            await _formContext.SaveChangesAsync();
            return true;
        }

        catch
        {
            return false;
        }
    }






}
