using AutoMapper;
using Project.DTOs.Comment;
using Project.Models;

namespace Project.Mappings;

public class CommentMapper : Profile
{
    public CommentMapper()
    {
        CreateMap<Comment, CommentReadDto>().ReverseMap();
        CreateMap<Comment, CommentDetailDto>().ReverseMap();
        CreateMap<Comment, CommentCreateDto>().ReverseMap();
        CreateMap<Comment, CommentUpdateDto>().ReverseMap();
    }
}
