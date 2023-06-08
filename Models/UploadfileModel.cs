using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace core7_vue3_azure.Models
{
    public class UploadfileModel {
        public int Id { get; set; }
        public IFormFile Profilepic { get; set; }

    }
    
}