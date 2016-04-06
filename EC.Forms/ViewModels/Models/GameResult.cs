using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Forms.ViewModels
{
    public class GameResult : CustomBaseModel
    {
        [JsonIgnore]
        public Challenge Challenge
        {
            get
            {
                return ChallengeId == null ? null : DataManager.Instance.Challenges.Get(ChallengeId);
            }
        }

        string _challengeId;

        public string ChallengeId
        {
            get
            {
                return _challengeId;
            }
            set
            {
                SetPropertyChanged(ref _challengeId, value);
            }
        }

        int? challengerScore;

        public int? ChallengerScore
        {
            get
            {
                return challengerScore;
            }
            set
            {
                SetPropertyChanged(ref challengerScore, value);
            }
        }

        int? challengeeScore;

        public int? ChallengeeScore
        {
            get
            {
                return challengeeScore;
            }
            set
            {
                SetPropertyChanged(ref challengeeScore, value);
            }
        }

        int? index;

        public int? Index
        {
            get
            {
                return index;
            }
            set
            {
                SetPropertyChanged(ref index, value);
            }
        }
    }
}
