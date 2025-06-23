using _3KatmanDigital_API.DTO.Project;
using _3KatmanDigital_API.DTO.ProjectImages;
using _3KatmanDigital_API.Repository.Interface;
using _3KatmanDigital_API.Services.Interface;
using Entitiy.Models;
using Microsoft.AspNetCore.Http;
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
            var allproject = await _projectRepo.GetAllAsync();
            return allproject.Select(p => new ProjectDto
            {
                ID = p.ID,
                Title = p.Title,
                Description = p.Description,
                CategoryID = p.CategoryID,
                Images = p.Images.Select(i => new ProjectImageDto
                {
                    ID = i.ID,
                    ImagePath = i.ImagePath,


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
            var getprjectbycategory = await _projectRepo.GetWhereListAsync(p => p.CategoryID == categoryId);
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
                }).ToList()
            }).ToList();
        }


        public async Task<ProjectDto> UpdateProjectAsync(UpdateProjectDto project)
        {
            var existingProject = await _projectRepo.GetProjectWithImageAsync(project.Id);

           

            if (project.Images != null && project.Images.Any())
            {
                string projectFolder = Path.Combine(_env.WebRootPath, "images", "projects", existingProject.ID.ToString());
                Directory.CreateDirectory(projectFolder); // Klasör yoksa oluştur

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





            await _projectRepo.UpdateAsync(existingProject);
            return new ProjectDto
            {
                ID = existingProject.ID,
                Title = existingProject.Title,
                Description = existingProject.Description,
                CategoryID = existingProject.CategoryID,
                Images = existingProject.Images.Select(i => new ProjectImageDto
                {
                    ID = i.ID,
                    ImagePath = i.ImagePath,
                }).ToList()
            };


        }
    }
}
