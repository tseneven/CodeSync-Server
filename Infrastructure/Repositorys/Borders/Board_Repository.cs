using API.Application.DTO;
using API.Infrastructure.Entities;
using backend.Infrastructure.Entities;
using backend.Infrastructure.Repositorys.Auth.Guards;
using Backend.Core.Database;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Repositorys.Board
{
    public class Board_Repository : IBoard_Repository
    {
        private readonly ApplicationContext _context;
        private readonly JWTService _jwtService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Board_Repository(ApplicationContext context, JWTService jwtService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _jwtService = jwtService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> CreateBorder(BoardDTO boardDTO)
        {
            try
            {
                boardDTO.date = DateTime.Now;

                Boards borders = new Boards
                {
                    UserID = int.Parse(boardDTO.UserID),
                    username = boardDTO.Username,
                    text = boardDTO.text,
                    haveImage = boardDTO.haveImage ?? false,
                    date = DateTime.Now,
                    repost = boardDTO.repost ?? 0,
                };


                _context.Add(borders);
                await _context.SaveChangesAsync();
                return "Запись создана";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public async Task<List<BoardList>> GetAll()
        {
            try
            {
                var boardList = await _context.Borders
                    .Include(b => b.user)
                    .Include(b => b.Likes)
                    .Select(b => new BoardList
                    {
                        Id = b.ID,
                        UserID = b.UserID,
                        Username = b.username,
                        text = b.text,
                        date = b.date,
                        likes = b.Likes.Select(l => new LikesDTO
                        {
                            Id = l.ID,
                            BoardId = l.BoardID,
                            UserId = l.UserID.ToString(),
                            Username = l.Username
                        }).ToList(),
                        countLikes = b.Likes.Count,
                        repost = b.repost
                    })
                    .ToListAsync();

                return boardList;
            }
            catch (Exception ex)
            {
                return new List<BoardList>();
            }
        }
        public async Task<string> LikeBoard(LikesDTO likes)
        {
            try
            {

                Likes like = new Likes 
                { 
                    UserID = int.Parse(likes.UserId), 
                    BoardID = likes.BoardId, 
                    Username = likes.Username 
                };

                _context.Add(like);
                await _context.SaveChangesAsync();
                return "Запись создана";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
