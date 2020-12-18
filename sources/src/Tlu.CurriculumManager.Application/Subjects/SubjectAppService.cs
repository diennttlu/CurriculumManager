using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tlu.CurriculumManager.Permissions;
using Tlu.CurriculumManager.Repositories;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Tlu.CurriculumManager.Subjects
{
    [Authorize]
    public class SubjectAppService : CrudAppService<
        Subject,
        SubjectDto,
        int,
        SubjectFilterDto,
        CreateUpdateSubjectDto,
        CreateUpdateSubjectDto>, ISubjectAppService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectAppService(
            IRepository<Subject, int> repository,
            ISubjectRepository subjectRepository) : base(repository)
        {
            _subjectRepository = subjectRepository;
        }

        [Authorize(CurriculumManagerPermissions.Subjects.Default)]
        public override Task<PagedResultDto<SubjectDto>> GetListAsync(SubjectFilterDto input)
        {
            var query = Repository.AsQueryable();
            if (input.Id.HasValue)
                query = query.Where(s => s.Id == input.Id);

            if (!string.IsNullOrEmpty(input.Code))
                query = query.Where(s => s.Code.Contains(input.Code));

            if (!string.IsNullOrEmpty(input.Name))
                query = query.Where(s => s.Name.Contains(input.Name));

            if (input.UnitMin.HasValue)
                query = query.Where(s => s.Unit >= input.UnitMin);

            if (input.UnitMax.HasValue)
                query = query.Where(s => s.Unit <= input.UnitMax);

            if (!string.IsNullOrEmpty(input.Condition))
                query = query.Where(s => s.Condition.Contains(input.Condition));

            if (!string.IsNullOrEmpty(input.HoursStudy))
                query = query.Where(s => s.HoursStudy.Contains(input.HoursStudy));

            if (input.CoefficientMin.HasValue)
                query = query.Where(s => s.Coefficient >= input.CoefficientMin);

            if (input.CoefficientMax.HasValue)
                query = query.Where(s => s.Coefficient <= input.CoefficientMax);

            var count = query.Count();

            if (!string.IsNullOrEmpty(input.Sorting))
                query = ApplySorting(query, input);

            if (input.MaxResultCount > 0)
                query = ApplyPaging(query, input);

            var items = query.ToList();
            var result = new PagedResultDto<SubjectDto>(count, ObjectMapper.Map<List<Subject>, List<SubjectDto>>(items));
            return Task.FromResult(result);
        }

        [Authorize(CurriculumManagerPermissions.Subjects.Default)]
        public override Task<SubjectDto> GetAsync(int id)
        {
            return base.GetAsync(id);
        }

        [Authorize(CurriculumManagerPermissions.Subjects.Edit)]
        public override Task<SubjectDto> UpdateAsync(int id, CreateUpdateSubjectDto input)
        {
            return base.UpdateAsync(id, input);
        }

        [Authorize(CurriculumManagerPermissions.Subjects.Delete)]
        public override Task DeleteAsync(int id)
        {
            return base.DeleteAsync(id);
        }

        public async Task<bool> ImportFile(IFormFile file)
        {
            try
            {
                using (var stream = file.OpenReadStream())
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (extension == ".xls" || extension == ".xlsx")
                    {
                        var hssfwb = new XSSFWorkbook(stream);
                        var sheet = hssfwb.GetSheetAt(0);
                        var cellCount = sheet.GetRow(0).Cells.Count();
                        
                        if (cellCount == 6)
                        {
                            var subjects = new List<Subject>();
                            var oldSubject = Repository.Select(x => x.Code).ToList();
                            var hashSet = new HashSet<string>(oldSubject);

                            for (int row = (sheet.FirstRowNum + 1); row <= sheet.LastRowNum; row++)
                            {
                                var getRow = sheet.GetRow(row);
                                if (getRow == null) 
                                    continue;
                                if (getRow.Cells.All(d => d.CellType == CellType.Blank))
                                    continue;
                                
                                if (hashSet.Add(sheet.GetRow(row).GetCell(0).ToString().Trim()))
                                {
                                    var subject = new Subject()
                                    {
                                        Code = sheet.GetRow(row).GetCell(0).ToString().Trim(),
                                        Name = sheet.GetRow(row).GetCell(1).ToString(),
                                        Unit = TryParseInt(sheet.GetRow(row).GetCell(2).ToString()),
                                        Condition = sheet.GetRow(row).GetCell(3) != null ? sheet.GetRow(row).GetCell(3).ToString() : null,
                                        HoursStudy = sheet.GetRow(row).GetCell(4) != null ? sheet.GetRow(row).GetCell(4).ToString() : null,
                                        Coefficient = TryParseDouble(sheet.GetRow(row).GetCell(5).ToString())
                                    };

                                    subjects.Add(subject);
                                }
                            }
                            await _subjectRepository.BulkInsertAsync(subjects);
                        } 
                        else
                            return await Task.FromResult(false);
                    } 
                    else
                        return await Task.FromResult(false);
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return await Task.FromResult(true);
        }

        [Authorize(CurriculumManagerPermissions.Subjects.Create)]
        public override Task<SubjectDto> CreateAsync(CreateUpdateSubjectDto input)
        {
            return base.CreateAsync(input);
        }

        private int TryParseInt(string value)
        {
            if (int.TryParse(value, out int result))
                return result;
            return 0;
        }

        private double TryParseDouble(string value)
        {
            if (double.TryParse(value, out double result))
                return result;
            return 0;
        }

    }
}
