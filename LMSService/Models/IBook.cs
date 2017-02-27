using System;

namespace LMSService.Models
{
    public interface IBook
    {
        Guid Id { get; }
        string Name { get; }
        string Author { get; }
        int Pages { get; }
        string ISBN { get; }
    }
}
