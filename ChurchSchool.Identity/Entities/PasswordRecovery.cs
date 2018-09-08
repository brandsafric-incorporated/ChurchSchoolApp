using ChurchSchool.Domain.Entities.Identity;
using ChurchSchool.Identity.Contracts;
using ChurchSchool.Identity.Model;
using ChurchSchool.Repository.Contracts;
using ChurchSchool.Service.Contracts;
using ChurchSchool.Service.Models;
using ChurchSchool.Shared;
using Microsoft.Extensions.Options;
using System;

namespace ChurchSchool.Identity.Entities
{
    public class PasswordRecovery : IPasswordRecovery
    {
        private readonly IUserRepository _userRepository;

        private readonly IEmailService _emailService;
        private readonly ApplicationSettings _options;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IViewRenderService _viewRenderService;

        public PasswordRecovery(IUserRepository userRepository,
                                IEmailService emailService,
                                IEmailTemplateService emailTemplateService,
                                IViewRenderService viewRenderService,
                                IOptions<ApplicationSettings> options)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _options = options.Value;
            _viewRenderService = viewRenderService;
        }

        public bool IsTokenValid(User user)
        {

            if (user == null || string.IsNullOrEmpty(user.PasswordRecoveryToken) || DateTime.Now.Subtract(user.PasswordRecoveryRequestedDate.Value).TotalMinutes > _options.RecoverPasswordSettings.TokenExpireTimeInMinutes)
                return false;

            return true;
        }

        public string GeneratePasswordRecoveryToken(User user)
        {
            var hashContent = Encrypt.Hash($"{user.Email}+{DateTime.Now}");
            return hashContent;
        }

        public string CreateRecoveryEmail(User user)
        {
            var renderedTemplate = _viewRenderService.RenderToStringAsync<PasswordRecoveryModel>("~/EmailTemplates/PasswordRecovery.cshtml",
                                                                                                 new PasswordRecoveryModel
                                                                                                 {
                                                                                                     ExpirationTokenInMinutes = _options.RecoverPasswordSettings.TokenExpireTimeInMinutes,
                                                                                                     PasswordRecoveryUrl = $"{_options.ApplicationBaseUri}/authentication/reset-password?key={user.PasswordRecoveryToken}",
                                                                                                     PersonName = user.UserName
                                                                                                 }).Result;
            return renderedTemplate;
        }
    }

}
