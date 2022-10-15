﻿using Functionland.FxFiles.Client.Shared.Extensions;

namespace Functionland.FxFiles.Client.Shared.Services.Implementations.OfflineAvailability
{
    public class FakeOfflineAvailabilityService : IOfflineAvailabilityService
    {
        private readonly List<FsArtifact>? _FsArtifacts= new();
        private readonly List<FsArtifact>? _AllFulaFsArtifacts = new();
        public TimeSpan? ActionLatency { get; set; }
        public TimeSpan? EnumerationLatency { get; set; }
        public IStringLocalizer<AppStrings> StringLocalizer { get; set; } = default!;

        public FakeOfflineAvailabilityService(IEnumerable<FsArtifact>? fsArtifacts = null,
                                              IEnumerable<FsArtifact>? allFulaFsArtifacts = null,
                                              TimeSpan? actionLatency = null,
                                              TimeSpan? enumerationLatency = null)
        {
            _FsArtifacts.Clear();
            _AllFulaFsArtifacts.Clear();

            ActionLatency = actionLatency ?? TimeSpan.FromSeconds(2);
            EnumerationLatency = enumerationLatency ?? TimeSpan.FromMilliseconds(10);

            if (fsArtifacts is not null)
            {
                foreach (var fsArtifact in fsArtifacts)
                {
                    _FsArtifacts.Add(fsArtifact);
                }
            }
            else
            {
                _FsArtifacts = new List<FsArtifact>();
            }

            if (allFulaFsArtifacts is not null)
            {
                foreach (var fsArtifact in allFulaFsArtifacts)
                {
                    _AllFulaFsArtifacts.Add(fsArtifact);
                }
            }
            else
            {
                _AllFulaFsArtifacts = new List<FsArtifact>();
            }
        }
        public async Task InitAsync(CancellationToken? cancellationToken = null)
        {

        }

        public async Task EnsureInitializedAsync(CancellationToken? cancellationToken = null)
        {

        }

        public async Task MakeAvailableOfflineAsync(FsArtifact artifact, CancellationToken? cancellationToken = null)
        {
            if (ActionLatency != null)
            {
                await Task.Delay(ActionLatency.Value);
            }

            _FsArtifacts?.Add(artifact);
        }

        public async Task RemoveAvailableOfflineAsync(FsArtifact artifact, CancellationToken? cancellationToken = null)
        {
            var lowerCaseArtifact = AppStrings.Artifact.ToLowerFirstChar();

            if (ActionLatency != null)
            {
                await Task.Delay(ActionLatency.Value);
            }

            if (artifact is null)
                throw new ArtifactDoseNotExistsException(StringLocalizer.GetString(AppStrings.ArtifactDoseNotExistsException, artifact?.ArtifactType.ToString() ?? lowerCaseArtifact));

            _FsArtifacts?.Remove(artifact);
        }

        public async Task<bool> IsAvailableOfflineAsync(FsArtifact artifact, CancellationToken? cancellationToken = null)
        {
            if (ActionLatency != null)
            {
                await Task.Delay(ActionLatency.Value);
            }

            if (artifact.IsAvailableOffline == true)
                return true;

            return false;
        }
    }
}