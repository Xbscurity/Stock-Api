using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<Comment, TResult>> selector)
        {
            return await _context.Comments.AsNoTracking()
            .Select(selector)
            .ToListAsync();
            
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return  await _context.Comments.FindAsync(id);
        }

        public async Task<Comment?> UpdateAsync(int id, Comment commentModel)
        {
            var existingComment = await _context.Comments.FindAsync(id);
            if(existingComment == null)
            {
                return null;
            }
            existingComment.Title = commentModel.Title;
            existingComment.Content = commentModel.Content;
            await _context.SaveChangesAsync();
            return existingComment; 
        }
public async Task<Comment?> DeleteAsync(int id)
{
    var commentModel = await _context.Comments.Include(c => c.Stock).FirstOrDefaultAsync(c => c.Id == id);
    if(commentModel == null)
    {
        return null;
    }
     _context.Comments.Remove(commentModel);
     await _context.SaveChangesAsync();
     return commentModel;
}
    }
}