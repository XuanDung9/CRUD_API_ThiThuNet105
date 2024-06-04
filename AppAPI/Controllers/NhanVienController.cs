using AppData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : ControllerBase
    {
        AppDbContext _context;
        public NhanVienController()
        {
            _context = new AppDbContext();
        }
        [HttpGet("nhanvien-get-all")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_context.NhanVien.ToList());
            }
            catch 
            {
                return BadRequest();
            }
        }
        [HttpGet("nhanvien-get-by-id")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var nhanvien = _context.NhanVien.Find(id);
                if (nhanvien != null)
                {
                    return Ok(nhanvien);
                }    
                else
                {
                    return NotFound();
                }    
              
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost("create-nhanvien")]
        public IActionResult Create(NhanVien nhanvien)
        {
            _context.NhanVien.Add(nhanvien);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut("update-nhanvien")]
        public IActionResult Edit(Guid id , NhanVien nhanvien)
        {
            try
            {
                var itemUpdate = _context.NhanVien.Find(id);
                    if(itemUpdate != null) 
                    {
                        itemUpdate.Ten = nhanvien.Ten;
                        itemUpdate.Tuoi = nhanvien.Tuoi;
                        itemUpdate.Role = nhanvien.Role;
                        itemUpdate.Email = nhanvien.Email;
                        itemUpdate.Luong = nhanvien.Luong;
                        itemUpdate.TrangThai = nhanvien.TrangThai;

                        _context.NhanVien.Update(itemUpdate);
                        _context.SaveChanges();
                        return Ok();   
                    }
                    else
                    {
                        return BadRequest();
                    }    
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("delete-nhanvien")]
        public IActionResult Delete(Guid id)
        {
            var deleteItem = _context.NhanVien.Find(id);
            if (deleteItem != null)
            {
                _context.NhanVien.Remove(deleteItem);
                _context.SaveChanges();
                return Ok();
            }    
            return BadRequest();
            
        }
    }
}
