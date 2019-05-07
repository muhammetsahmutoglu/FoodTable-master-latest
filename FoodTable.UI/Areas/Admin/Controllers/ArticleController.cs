using FoodTable.Model.Option;
using FoodTable.Service.Option;
using FoodTable.UI.Areas.Admin.Models.DTO;
using FoodTable.UI.Areas.Admin.Models.VM;
using FoodTable.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodTable.UI.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        
        AppUserService _appUserService;
        CategoryService _categoryService;
        ArticleService _articleService;
        public ArticleController()
        {
            
            _appUserService = new AppUserService();
            _categoryService = new CategoryService();
            _articleService = new ArticleService();

        }
        public ActionResult Add()
        {
            ArticleVM model = new ArticleVM()
            {
                AppUsers = _appUserService.GetActive(),
              Categories = _categoryService.GetActive(),
              

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Article Data)
        {
            _articleService.Add(Data);
            return Redirect("/Admin/Article/List");
        }
        public ActionResult List()
        {
            List<Article> model = _articleService.GetActive().Take(10).ToList();
            return View(model);
        }
        public ActionResult Show(Guid id)
        {
            Article article = _articleService.GetByID(id);
            ArticleVM model = new ArticleVM()
            {
                Categories = _categoryService.GetActive().Take(5).ToList()

            };
            model.article.ID = article.ID;
            model.article.Content = article.Content;
            model.article.Header = article.Header;
            model.appUser.UserName = article.AppUser.UserName;
            model.CreatedDate = article.CreatedDate;
            
            return View(model);
        }
        public ActionResult Update(Guid id)
        {
            Article article = _articleService.GetByID(id);
            ArticleVM model = new ArticleVM();
            model.article.ID = article.ID;
            model.article.Content = article.Content;
            model.article.Header = article.Header;
            List<Category> categories = _categoryService.GetActive();
            List<AppUser> appUsers = _appUserService.GetActive();
            
            model.Categories = categories;
            
            model.AppUsers = appUsers;
            model.article.ImagePath = article.ImagePath;
            return View(model);
            
        }
        [HttpPost]
        public ActionResult Update(ArticleDTO data,HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.ImagePath = UploadedImagePaths[0];


            Article update = _articleService.GetByID(data.ID);

            if (data.ImagePath == "0" || data.ImagePath == "1" || data.ImagePath == "2")
            {

                if (update.ImagePath == null || update.ImagePath == ImageUploader.DefaultProfileImagePath)
                {
                    update.ImagePath = ImageUploader.DefaultProfileImagePath;
                    update.ImagePath = ImageUploader.DefaultXSmallProfileImage;
                    update.ImagePath = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    update.ImagePath = data.ImagePath;
                }

            }
            else
            {
                update.ImagePath = UploadedImagePaths[0];
                update.ImagePath = UploadedImagePaths[1];
                update.ImagePath = UploadedImagePaths[2];
            }


            update.ImagePath = data.ImagePath;
            update.Content = data.Content;
            update.Header = data.Header;


            _articleService.Update(update);

            return Redirect("/Admin/Article/List");


        }
        public RedirectResult Delete(Guid id)
        {
            _articleService.Remove(id);
            return Redirect("/Admin/Article/List");
        }
    }
}