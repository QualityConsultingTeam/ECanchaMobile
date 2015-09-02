using EC.DocumentResponse;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EC.Forms.ViewModels
{

    public class FieldsViewModel : BaseTabbedViewModel
    {

        public FieldsViewModel(Page currentPage)
            : base(currentPage)
        {
            
        }
         
    
        #region ListView Update News
    
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChange();
            }
        }


        public Command GetLatestNewsCommand
        {
            get
            {
                return UpdateNewsCommand ??
                    (UpdateNewsCommand = new Command(ExecuteGetLatestCommand, () => { return !IsBusy; }));
            }
        }

        private Command UpdateNewsCommand;



        /// <summary>
        /// Evento para actualizar la vista con las nuevas noticias
        /// </summary>
        private async void ExecuteGetLatestCommand()
        {
            await GetDataWaiting();
        }

        private bool isBusy;

        #endregion


        #region ListView Data Source

        public List<Field> FieldsCollection
        {
            get { return _all; }
            set
            {
                _all = value;
                OnPropertyChange();
            }
        }



        internal void LoadData()
        {
            
                        //Task.Factory.StartNew(async () => Device.BeginInvokeOnMainThread(async () =>
                        //             {
                        //                 await GetDataWaiting();

                        //             }), CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

            Task.Run( () => GetDataWaiting());

        }


        /// <summary>
        /// Cargar los datos con el efecto de Waiting
        /// </summary>
        /// <returns></returns>
        private async Task GetDataWaiting()
        {
            if (IsBusy) return;
            FieldsCollection = await CoreClient.FieldsService.GetFields(new FilterOptionModel() { });
            IsBusy = false;
            //var ItemsSQLITE = await GetAllNewsSQLITE();

            //if (!ItemsSQLITE.Any())
            //{
            //    if (Device.OS == TargetPlatform.iOS) IsBusyIOS = true;
            //    IsBusy = true;
            //}

            //GetLatestNewsCommand.ChangeCanExecute();

            //await FillListAll(ItemsSQLITE);

            //IsBusy = false;
            //if (Device.OS == TargetPlatform.iOS) IsBusyIOS = false;

            //GetLatestNewsCommand.ChangeCanExecute();

            // TODO LOAD DATA
        }


        /// <summary>
        /// Crear lista completa de elementos en base de datos y los descargados del web services
        /// </summary>
        /// <returns></returns>
        private async Task FillListAll(List<Field> ItemsSQLITE)
        {
            //if (HasAnyChange(ItemsSQLITE))
            //    All = ItemsSQLITE;

            //if (!ItemsSQLITE.Any())
            //{
            //    await FillListView();
            //}
            //else
            //{
            //    Task.Factory.StartNew(async () => Device.BeginInvokeOnMainThread(async () =>
            //    {
            //        await FillListView();
            //    }));
            //}

        }

        private bool HasAnyChange(List<Field> ItemsSQLITE)
        {
            if (ItemsSQLITE == null)
            {
                // si no hay ningun elemento en la base de datos local, no necesita asignarlo e ira a descargar los datos su primer vez
                return false;
            }

            if (FieldsCollection == null)
            {
                // All esta nulo por lo que fue su primera vez necesita refrescar, si viene algun item
                return true;
            }



            var hasChange = false;

            //foreach (var item in ItemsSQLITE)
            //{
            //    var itemShowed = All.FirstOrDefault(a => a.IDWS == item.IDWS);

            //    if (itemShowed == null)
            //    {
            //        hasChange = true;
            //    }
            //    else
            //    {
            //        hasChange = NewsController.HasChange(item, itemShowed);
            //    }

            //    if (hasChange)
            //    {
            //        break;
            //    }
            //

            return hasChange;
        }


        /// <summary>
        /// recargar la ListView si hay cambios en la base de datos local
        /// </summary>
        /// <returns></returns>
        private async Task FillListView()
        {
            //bool wasUpdated = false;

            //// actualizar la DB con las noticias nuevas, si hay conexion a internet (WS)
            //if (CheckInternetAcces())
            //{
            //    wasUpdated = await UpdateLocalStore();
            //}

            //if (wasUpdated)
            //{
            //    All = await GetAllNewsSQLITE();
            //}
        }


        ///// <summary>
        ///// Traer todas las News de las base de datos SQLITE
        ///// </summary>
        ///// <returns></returns>
        //private async Task<List<News>> GetAllNewsSQLITE()
        //{
        //    // Traer datos de la db  ( se agrega a la lista luego de la descarga, ya que en la descarga se actualiza la DB)                      
        //    List<News> FinalList = new List<News>();
        //    foreach (var item in NewsController.Instance.GetNews())
        //    {
        //        FinalList.Add(await CloneObjectUpdated(item));
        //    }

        //    return FinalList.OrderByDescending(a => a.Range).ToList();
        //}


        /// <summary>
        /// Actualizacion de la base de datos local con los ultimos cambios en el servidor
        /// </summary>
        /// <returns></returns>
        //private async Task<bool> UpdateLocalStore()
        //{
        //    bool returnbOOL = false;

        //    // noticias recibidas desde el servidor
        //    List<int> IDsServer = new List<int>();

        //    // traer las ultimas noticias de la Web y agregarlas a las lista                                    
        //    foreach (var item in await GetDataWS<News>(Constantes.ServiceNews))
        //    {
        //        IDsServer.Add(item.Id);

        //        // en este momento el id es el de la base en ws
        //        var LocalRow = NewsController.Instance.GetNew(item.Id);

        //        if (LocalRow == null)
        //        {
        //            // asignar id de la base sql a el indice sqlite
        //            item.IDWS = item.Id;

        //            // descargar la imagen que posee la noticia                    
        //            if (!string.IsNullOrEmpty(item.Image))
        //            {
        //                item.LocalImage = NewsHelper.GetRandomNameImage();
        //                // descargar imagen a dispositivo para luego cargarla en vista
        //                await DependencyService.Get<IDownloader>().DownloadImage(item.LocalImage, item.Image);
        //            }

        //            // Guardar las Noticias descargadas en la base de datos local                
        //            NewsController.Instance.AddNew(item);

        //            returnbOOL = true;
        //        }
        //        else
        //        {

        //            // descargar la imagen que posee la noticia porque fue actualizada
        //            if (item.Image != LocalRow.Image)
        //            {
        //                LocalRow.LocalImage = NewsHelper.GetRandomNameImage();
        //                // descargar imagen a dispositivo para luego cargarla en vista
        //                await DependencyService.Get<IDownloader>().DownloadImage(LocalRow.LocalImage, item.Image);

        //                returnbOOL = true;
        //            }

        //            // actualizar si es necesario
        //            var fueActualizado = NewsController.Instance.UpdateNew(item, LocalRow);

        //            returnbOOL = fueActualizado ? true : returnbOOL;
        //        }
        //    }

        //    // si hay algun id localmente que no haya sido retornado por el servidor se procedera a borarse localmente, ya que fue eliminada o deshabilitado en el servidor
        //    foreach (var localNew in NewsController.Instance.GetNews().ToList())
        //    {
        //        if (!IDsServer.Any(a => a == localNew.IDWS))
        //        {
        //            // borrar estados locales que ya no estan en servidor
        //            NewsController.Instance.DeleteNew(localNew);

        //            returnbOOL = true;
        //        }
        //    }

        //    return returnbOOL;
        //}


        /// <summary>
        /// Crear un nuevo objeto agregandole propiedades enriquesidas
        /// </summary>
        /// <param name="CNew"></param>
        /// <returns></returns>
        //private async Task<Field> CloneObjectUpdated(Field field)
        //{
           

        //    if (Device.OS == TargetPlatform.iOS)
        //    {
        //        if (field .LocalImage != null)
        //            obj.NewsImage = await DependencyService.Get<IDownloader>().LoadDownloadedImage(CNew.LocalImage, 30, 100);
        //    }
        //    else
        //    {
        //        obj.NewsImage = !string.IsNullOrEmpty(CNew.LocalImage) ? await DependencyService.Get<IDownloader>().LoadDownloadedImage(CNew.LocalImage, 30, 100) : string.Empty;
        //    }

        //    return obj;
        //}


        #endregion



        private ImageSource GetIconNews(IconNews icon)
        {
            //switch (icon)
            //{
            //    case IconNews.News:
            //        return Constants.NewsImageSource;
            //    case IconNews.Events:
            //        return Constants.WorkshopsImageSource;
            //    case IconNews.Research:
            //        return Constants.ResearchImageSource;
            //    case IconNews.Talk:
            //        return Constants.TalkImageSource;
            //    case IconNews.Rewards:
            //        return Constants.RewardsImageSource;
            //    case IconNews.Interview:
            //        return Constants.InterviewImageSource;
            //    case IconNews.Fovorite:
            //        return Constants.FavoriteImageSource;
            //    case IconNews.Information:
            //        return Constants.InfoImageSource;
            //    case IconNews.Discover:
            //        return Constants.DiscoverImageSource;

            //}

            return null;
        }

        enum IconNews
        {
            News,
            Events,
            Research,
            Talk,
            Discover,
            Rewards,
            Interview,
            Fovorite,
            Information
        }



        #region Private Fields

        private List<Field> _all;

        #endregion


    }
}
