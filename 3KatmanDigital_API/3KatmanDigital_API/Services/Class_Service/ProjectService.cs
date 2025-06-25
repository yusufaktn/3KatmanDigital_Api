using _3KatmanDigital_API.DTO.Project;
using _3KatmanDigital_API.DTO.ProjectImages;
using _3KatmanDigital_API.Repository.Interface;
using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Net.Mime.MediaTypeNames;


namespace _3KatmanDigital_API.Services.Class_Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepo _projectRepo;
        private readonly IProjectImageRepo _projectImageRepo;
        private readonly IWebHostEnvironment _env;
        public ProjectService(IProjectRepo projectRepo, IProjectImageRepo projectImageRepo, IWebHostEnvironment env)
        {
            _projectRepo = projectRepo;
            _projectImageRepo = projectImageRepo;
            _env = env;
        }


        public async Task<ProjectDto> AddProjectAsync(CreateProjectDto project)
        {
            var newProject = new Project
            {
                Title = project.Title,
                Description = project.Description,
                CategoryID = project.CategoryID,
            };
            await _projectRepo.AddAsync(newProject);

            if (project.Images != null && project.Images.Any())
            {
                string projectFolder = Path.Combine(_env.WebRootPath, "images", "projects", newProject.ID.ToString());
                Directory.CreateDirectory(projectFolder); // Klasör yoksa oluştur

                foreach (var image in project.Images)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string filePath = Path.Combine(projectFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    var relativePath = Path.Combine("images", "projects", newProject.ID.ToString(), fileName).Replace("\\", "/");

                    var newImage = new ProjectImages
                    {
                        ProjectID = newProject.ID,
                        ImagePath = relativePath
                    };

                    await _projectImageRepo.AddAsync(newImage);
                }
            }

            return new ProjectDto
            {
                ID = newProject.ID,
                Title = newProject.Title,
                Description = newProject.Description,
                CategoryID = newProject.CategoryID,
                Images = new List<ProjectImageDto>() // istersen buraya da ekle
            };

        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            return await _projectRepo.DeleteAsync(id);
        }

        public async Task<List<ProjectDto>> GetAllProjectsAsync()
        {
            var allproject = await _projectRepo.GetProjectWithImageAllAsync();

            return allproject.Select(p => new ProjectDto
            {
                ID = p.ID,
                Title = p.Title,
                Description = p.Description,
                CategoryID = p.CategoryID,
                Images = (p.Images?? new List<ProjectImages>()) .Select(i => new ProjectImageDto
                {
                    ID = i.ID,
                    ImagePath = i.ImagePath,
                    ProjectID = i.ProjectID


                }).ToList()
            }).ToList();
        }

        public async Task<ProjectDto> GetProjectByIdAsync(Guid id)
        {
            var getıd = await _projectRepo.GetProjectWithImageAsync(id);
            if (getıd == null)
            {
                 throw new Exception("Project not found.");
            }

            return new ProjectDto
            {
                ID = getıd.ID,
                Title = getıd.Title,
                Description = getıd.Description,
                CategoryID = getıd.CategoryID,
                Images = getıd.Images?.Select(i => new ProjectImageDto
                {
                    ID = i.ID,
                    ImagePath = i.ImagePath,
                    ProjectID = i.ProjectID
                }).ToList()
            };
        }

        public async Task<List<ProjectDto>> GetProjectsByCategoryIdAsync(Guid categoryId)
        {
            var getprjectbycategory = await _projectRepo.GetProjectWithImageCategoryIDAsync(categoryId);
            return getprjectbycategory.Select(p => new ProjectDto
            {
                ID = p.ID,
                Title = p.Title,
                Description = p.Description,
                CategoryID = p.CategoryID,
                Images = p.Images.Select(i => new ProjectImageDto
                {
                    ID = i.ID,
                    ImagePath = i.ImagePath,
                    ProjectID = i.ProjectID
                }).ToList()
            }).ToList();
        }



        public async Task<ProjectDto> UpdateProjectAsync(UpdateProjectDto project)
        {
            var existingProject = await _projectRepo.GetProjectWithImageAsync(project.Id);

            if (existingProject == null)
            {
                throw new Exception("Proje bulunamadı.");
            }

            // Proje alanlarını yeni verilerle güncelleyin
            existingProject.Title = project.Title;
            existingProject.Description = project.Description;
            existingProject.CategoryID = project.CategoryID;
            existingProject.UpdatedTime = DateTime.Now;

            // Resim güncelleme mantığı (isteğe bağlı, aşağıda açıklanmıştır)
            if (project.Images != null && project.Images.Any())
            {
                // Mevcut resimleri silme (isteğe bağlı)
                foreach (var image in existingProject.Images.ToList())
                {
                    var imagePath = Path.Combine(_env.WebRootPath, image.ImagePath);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                    await _projectImageRepo.DeleteAsync(image.ID);
                }

                // Yeni resimleri ekleme
                string projectFolder = Path.Combine(_env.WebRootPath, "images", "projects", existingProject.ID.ToString());
                Directory.CreateDirectory(projectFolder);

                foreach (var image in project.Images)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    string filePath = Path.Combine(projectFolder, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }

                    var relativePath = Path.Combine("images", "projects", existingProject.ID.ToString(), fileName).Replace("\\", "/");

                    var newImage = new ProjectImages
                    {
                        ProjectID = existingProject.ID,
                        ImagePath = relativePath
                    };

                    await _projectImageRepo.AddAsync(newImage);
                }
            }

            await _projectRepo.UpdatePojectAsyncWithImage(existingProject);

            var updatedDto = await GetProjectByIdAsync(existingProject.ID); // Güncellenmiş veriyi tekrar çek
            return updatedDto;
        }
    }
}
