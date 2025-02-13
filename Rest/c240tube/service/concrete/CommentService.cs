using c240tube.context;
using c240tube.dto.request;
using c240tube.entity;
using c240tube.mapper;
using c240tube.service.abstracts;

namespace c240tube.service.concrete
{
    public class CommentService : ICommentService
    {
        private readonly C240tube _context;
        private readonly ICustomerService _customerService;

        public CommentService(C240tube context,
            ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }
        public void AddComment(CommentSaveRequestDto dto)
        {
            Customer? customer = _customerService.getById(dto.customerId);

            if (customer == null)
            {
                throw new Exception(dto.customerId + " idye sahip customer bulunamadi");
            }



            Comment comment = CommentMapper.toComment(dto);

            _context.Comment.Add(comment);
            _context.SaveChanges();

        }


    }
}
