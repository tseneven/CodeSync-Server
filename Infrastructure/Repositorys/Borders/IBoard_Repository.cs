using API.Application.DTO;

namespace API.Infrastructure.Repositorys.Board
{
    public interface IBoard_Repository
    {
        Task<string> CreateBorder(BoardDTO borderDTO);
        Task<List<BoardList>> GetAll();
    }
}
