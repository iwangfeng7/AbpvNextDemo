using AutoMapper;
using wf.abp.Application.Contracts;
using wf.abp.Domain.Books;

namespace wf.abp.Application
{
    public class BookStoreApplicationAutoMapperProfile : Profile
    {
        public BookStoreApplicationAutoMapperProfile()
        {
            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>();
        }
    }
}