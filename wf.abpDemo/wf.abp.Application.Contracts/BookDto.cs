using System;
using Volo.Abp.Application.Dtos;
using wf.abp.Domain.Shared.Books;

namespace wf.abp.Application.Contracts
{
    public class BookDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public BookType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}