Prompt 1: Proje Kurulumu ve İsimlendirme

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim



Açıklama: Proje isimlendirme ve klasör yapısı için şirketin naming convention kurallarına uygun bir başlangıç yapıldı. IInteractable arayüzü ve InteractionDetector sistemi kuruldu.



Prompt 2:

ScriptableObject ve Key Interaction

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim



Açıklama: Genişletilebilir bir envanter yapısı için ItemData ScriptableObject yapısı kuruldu. KeyPickup sınıfı IInteractable arayüzünden türetilerek "Instant Interaction" tipi örneklendi.



Prompt 3: Inventory System Implementation

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim



Açıklama: Kilitli kapı gereksinimini karşılamak için InventoryController sınıfı Singleton pattern kullanılarak yazıldı. KeyPickup ile envanter sistemi arasındaki bağ kuruldu.





Prompt 4: IInteractable Interface Tasarımı

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt kullandım



Prompt: "IInteractable dosyasını oluşturdum, içeriği standartlara uygun nasıl olmalı?" Açıklama: Ludu Arts C# standartlarına (XML Documentation, Region kullanımı, Namespace yapısı) tam uyumlu bir interface tasarımı alındı ve uygulandı.

Alınan Cevap:
using UnityEngine;



namespace MuratAltin.Runtime.Core

{

&nbsp;   /// <summary>

&nbsp;   /// Etkileşime geçilebilir tüm nesnelerin uygulaması gereken temel arayüz.

&nbsp;   /// </summary>

&nbsp;   public interface IInteractable

&nbsp;   {

&nbsp;       #region Properties



&nbsp;       /// <summary>

&nbsp;       /// Etkileşim sırasında ekranda görünecek isim/başlık.

&nbsp;       /// </summary>

&nbsp;       string InteractionTitle { get; }



&nbsp;       /// <summary>

&nbsp;       /// Etkileşim türüne göre değişen açıklama metni (Örn: "Aç", "Topla").

&nbsp;       /// </summary>

&nbsp;       string InteractionDescription { get; }



&nbsp;       /// <summary>

&nbsp;       /// Bu nesneyle şu an etkileşime geçilebilir mi?

&nbsp;       /// </summary>

&nbsp;       bool CanInteract { get; }



&nbsp;       #endregion



&nbsp;       #region Methods



&nbsp;       /// <summary>

&nbsp;       /// Etkileşim tetiklendiğinde çalışacak ana metod.

&nbsp;       /// </summary>

&nbsp;       void Interact();



&nbsp;       #endregion

&nbsp;   }

}





Prompt 5: Asset Seçimi ve Greybox Kararı

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim





Benim Promptum: Objeleri nereden bulacağım kapıyı falan yoksa herhangi bir şey mi koyayım  küp tarzı

Açıklama: Teknik mimariye ve Ludu Arts standartlarına odaklanmak amacıyla, modeller için Unity Primitive objeleri kullanılarak "Greyboxing" yöntemi tercih edildi. Objeler, Prefab\_Asset\_Kurallari.md dokümanındaki hiyerarşi kurallarına (Root > Visual > Collider) göre yapılandırıldı





Prompt 6: Door Toggle Mechanism

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt kullandım

Benim Promptum: Kapı açılma scriptini bana uygun prensiplerde SOLİD yapısında kurar mısın ?

Açıklama: "Toggle Interaction" gereksinimi için Door sınıfı oluşturuldu. Quaternion.Slerp kullanılarak yumuşak bir açılma animasyonu sağlandı. Şirketin m\_ prefix ve Region standartları uygulandı

Alınan Cevap : 
using UnityEngine;

using MuratAltin.Runtime.Core;



namespace MuratAltin.Runtime.Interactables

{

&nbsp;   /// <summary>

&nbsp;   /// Basit bir açılır/kapanır kapı mekanizması.

&nbsp;   /// </summary>

&nbsp;   public class Door : MonoBehaviour, IInteractable

&nbsp;   {

&nbsp;       #region Fields



&nbsp;       \[Header("Settings")]

&nbsp;       \[SerializeField] private float m\_OpenRotation = 90f;

&nbsp;       \[SerializeField] private float m\_AnimationSpeed = 2f;



&nbsp;       \[Header("State")]

&nbsp;       \[SerializeField] private bool m\_IsOpen = false;

&nbsp;       \[SerializeField] private bool m\_CanInteract = true;



&nbsp;       private Quaternion m\_ClosedRotation;

&nbsp;       private Quaternion m\_TargetRotation;



&nbsp;       #endregion



&nbsp;       #region Properties



&nbsp;       public string InteractionTitle => "Kapı";

&nbsp;       public string InteractionDescription => m\_IsOpen ? "Kapat" : "Aç";

&nbsp;       public bool CanInteract => m\_CanInteract;



&nbsp;       #endregion



&nbsp;       #region Unity Methods



&nbsp;       private void Awake()

&nbsp;       {

&nbsp;           // Başlangıç rotasyonunu kaydet (Kapalı hali)

&nbsp;           m\_ClosedRotation = transform.localRotation;

&nbsp;           m\_TargetRotation = m\_ClosedRotation;

&nbsp;       }



&nbsp;       private void Update()

&nbsp;       {

&nbsp;           // Kapıyı hedef rotasyona yumuşak bir şekilde döndür (Slerp)

&nbsp;           transform.localRotation = Quaternion.Slerp(transform.localRotation, m\_TargetRotation, Time.deltaTime \* m\_AnimationSpeed);

&nbsp;       }



&nbsp;       #endregion



&nbsp;       #region Methods



&nbsp;       /// <summary>

&nbsp;       /// Kapının durumunu değiştirir (Toggle).

&nbsp;       /// </summary>

&nbsp;       public void Interact()

&nbsp;       {

&nbsp;           m\_IsOpen = !m\_IsOpen;



&nbsp;           if (m\_IsOpen)

&nbsp;           {

&nbsp;               m\_TargetRotation = m\_ClosedRotation \* Quaternion.Euler(0, m\_OpenRotation, 0);

&nbsp;           }

&nbsp;           else

&nbsp;           {

&nbsp;               m\_TargetRotation = m\_ClosedRotation;

&nbsp;           }



&nbsp;           Debug.Log(m\_IsOpen ? "Kapı Açıldı" : "Kapı Kapandı");

&nbsp;       }



&nbsp;       #endregion

&nbsp;   }

}





Prompt 7: Interaction Detector Implementation

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Kapı açılmıyor. Sebebi ne olabilir bulamadım araştırıp ?

Açıklama: Oyuncunun bakış doğrultusundaki nesneleri algılayıp etkileşimi tetikleyen InteractionDetector sistemi yazıldı. Kapı ve oyuncu arasındaki iletişim kuruldu.





Prompt 8: Animation Integration for Interactables

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Kod ile döndürmek yerine Animasyonla döndürmeyi kabul ediyor muydu Ludu Arts ?

Açıklama: Case dokümanındaki Bonus gereksinimleri karşılamak amacıyla kod tabanlı rotasyon (Slerp) yerine Animator tabanlı sistem kullanıldı. A\_ ve AC\_ prefix kurallarına uygun asset'ler oluşturuldu.





Prompt 9: Toggle Synchronization and Inspector Debugging

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Biz istediğimiz zaman aç / kapat yapamıyoruz. Buna bakalım .

Açıklama: OnValidate metodu eklenerek Inspector üzerinden yapılan değişikliklerin anlık olarak Animator'a yansıması sağlandı. Interact metodu ile tuş girişi ve görsel durum senkronize edildi.





Prompt 10: UI Feedback and Range Control

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt kullandım

Benim Promptum: Canvasdan Text oluşturdum. Kapının yanına gelince bu Text aktif olsun. Bana bunun kodunu verir misin ?

Açıklama: InteractionUI sınıfı oluşturularak dinamik metin sistemi kuruldu. InteractionDetector menzil kontrolü yapacak ve UI panelini otomatik gizleyip/gösterecek şekilde güncellendi. "Must Have" listesindeki UI gereksinimleri tamamlandı.

Alınan cevap :
using UnityEngine;

using TMPro; // TextMeshPro kullandığını varsayıyorum

using MuratAltin.Runtime.Core;



namespace MuratAltin.Runtime.UI

{

&nbsp;   /// <summary>

&nbsp;   /// Oyuncunun baktığı nesneye göre ekrandaki etkileşim yazısını günceller.

&nbsp;   /// </summary>

&nbsp;   public class InteractionUI : MonoBehaviour

&nbsp;   {

&nbsp;       #region Fields



&nbsp;       \[Header("UI References")]

&nbsp;       \[SerializeField] private GameObject m\_PromptPanel;

&nbsp;       \[SerializeField] private TextMeshProUGUI m\_PromptText;



&nbsp;       #endregion



&nbsp;       #region Methods



&nbsp;       /// <summary>

&nbsp;       /// Etkileşim panelini gösterir ve metni nesneye göre günceller.

&nbsp;       /// </summary>

&nbsp;       public void Show(IInteractable interactable)

&nbsp;       {

&nbsp;           if (interactable == null) return;



&nbsp;           m\_PromptPanel.SetActive(true);

&nbsp;           m\_PromptText.text = $"{interactable.InteractionTitle}\\n\[E] {interactable.InteractionDescription}";

&nbsp;       }



&nbsp;       /// <summary>

&nbsp;       /// Etkileşim panelini gizler.

&nbsp;       /// </summary>

&nbsp;       public void Hide()

&nbsp;       {

&nbsp;           m\_PromptPanel.SetActive(false);

&nbsp;       }



&nbsp;       #endregion

&nbsp;   }

}



private void Update()

{

&nbsp;   DetectInteractable();

&nbsp;   

&nbsp;   if (Input.GetKeyDown(KeyCode.E) \&\& m\_CurrentInteractable != null)

&nbsp;   {

&nbsp;       if (m\_CurrentInteractable.CanInteract)

&nbsp;       {

&nbsp;           m\_CurrentInteractable.Interact();

&nbsp;           // Etkileşimden sonra yazıyı hemen güncelle (Örn: "Aç" -> "Kapat")

&nbsp;           m\_InteractionUI.Show(m\_CurrentInteractable);

&nbsp;       }

&nbsp;   }

}



private void DetectInteractable()

{

&nbsp;   Ray ray = new Ray(m\_CameraTransform.position, m\_CameraTransform.forward);

&nbsp;   

&nbsp;   if (Physics.Raycast(ray, out RaycastHit hit, m\_InteractionRange, m\_InteractableLayer))

&nbsp;   {

&nbsp;       if (hit.collider.TryGetComponent(out IInteractable interactable))

&nbsp;       {

&nbsp;           m\_CurrentInteractable = interactable;

&nbsp;           m\_InteractionUI.Show(m\_CurrentInteractable); // Yazıyı göster

&nbsp;           return;

&nbsp;       }

&nbsp;   }



&nbsp;   m\_CurrentInteractable = null;

&nbsp;   m\_InteractionUI.Hide(); // Menzilden çıkınca gizle

}







Prompt 11: Basic Player Controller and Movement

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt kullandım

Benim Promptum: Basic bir tane CharacaterController scripti yazar mısın?

Açıklama: Test sürecini kolaylaştırmak için CharacterController tabanlı, FPS bakış açısına uygun hareket ve bakış sistemi (PlayerController) eklendi. Mouse Lock ve Movement entegrasyonu sağlandı.

Alınan Cevap :
using UnityEngine;



namespace MuratAltin.Runtime.Player

{

&nbsp;   \[RequireComponent(typeof(CharacterController))]

&nbsp;   public class PlayerController : MonoBehaviour

&nbsp;   {

&nbsp;       #region Fields

&nbsp;       \[Header("Movement Settings")]

&nbsp;       \[SerializeField] private float m\_MoveSpeed = 5f;

&nbsp;       \[SerializeField] private float m\_MouseSensitivity = 2f;



&nbsp;       private CharacterController m\_Controller;

&nbsp;       private float m\_XRotation = 0f;

&nbsp;       #endregion



&nbsp;       private void Awake()

&nbsp;       {

&nbsp;           m\_Controller = GetComponent<CharacterController>();

&nbsp;           // Fareyi ekranın ortasına kilitle

&nbsp;           Cursor.lockState = CursorLockMode.Locked;

&nbsp;       }



&nbsp;       private void Update()

&nbsp;       {

&nbsp;           HandleRotation();

&nbsp;           HandleMovement();

&nbsp;       }



&nbsp;       private void HandleRotation()

&nbsp;       {

&nbsp;           float mouseX = Input.GetAxis("Mouse X") \* m\_MouseSensitivity;

&nbsp;           float mouseY = Input.GetAxis("Mouse Y") \* m\_MouseSensitivity;



&nbsp;           m\_XRotation -= mouseY;

&nbsp;           m\_XRotation = Mathf.Clamp(m\_XRotation, -90f, 90f);



&nbsp;           Camera.main.transform.localRotation = Quaternion.Euler(m\_XRotation, 0f, 0f);

&nbsp;           transform.Rotate(Vector3.up \* mouseX);

&nbsp;       }



&nbsp;       private void HandleMovement()

&nbsp;       {

&nbsp;           float x = Input.GetAxis("Horizontal");

&nbsp;           float z = Input.GetAxis("Vertical");



&nbsp;           Vector3 move = transform.right \* x + transform.forward \* z;

&nbsp;           m\_Controller.Move(move \* m\_MoveSpeed \* Time.deltaTime);

&nbsp;       }

&nbsp;   }

}





Prompt 12: Interaction Debugging

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Panel açılmıyor. Bunu çözmek için bir tane Ray yazalım. Ve bunu görselleştirelim.



Açıklama: Interaction Panel'in tetiklenmeme sorunu için Debug.DrawRay kullanılarak görsel hata ayıklama yapıldı. LayerMask ve Raycast Range değerleri optimize edildi.





Prompt 13: Raycast Hit Hierarchy Optimization

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Tamamdır çalıştı. Fakat \_Door objesine Box Collider atayınca çalıştı büyük ihtimalle child a vermiyordu. Childa verebilecek şekilde yazalım.



Açıklama: Raycast'in child nesnelere (Mesh) çarpması durumunda root nesnedeki scripti tetikleyememesi sorunu analiz edildi. P\_Door (Root) üzerine collider taşınarak geçici çözüm sağlandı. Kalıcı çözüm için GetComponentInParent mantığı koda dahil edildi.





Prompt 14: Animator Toggle Bug Fix

Araç: Gemini Tarih 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt Kullandım.

Benim Promptum: Yazı değişmesine rağmen Animasyon çalışmıyor. Neden acaba. Aklıma bir şey gelmedi. Yardımcı olur musun ?



Açıklama: Kapının ikinci kez etkileşime girmemesi sorunu, Animator Transition ayarları ve "Any State" mantığı kullanılarak optimize edildi. Has Exit Time çakışmaları giderildi.

Alınan cevap :
private void SyncAnimator()

{

&nbsp;   if (m\_Animator != null)

&nbsp;   {

&nbsp;       m\_Animator.SetBool(k\_OpenParam, m\_IsOpen);

&nbsp;       // Bunu ekleyerek Console'dan kontrol et:

&nbsp;       Debug.Log($"Animator Güncellendi: {k\_OpenParam} = {m\_IsOpen}");

&nbsp;   }

}





Prompt 15: Initial State and Animation Flow

Araç: Gemini Tarih 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Animasyonda sorun var . Bunu Idle ile yapalım.



Açıklama: Oyunun başında kapanma animasyonunun otomatik oynaması sorunu, Animator içine bir "Idle" default state eklenerek çözüldü. State Machine akışı (Idle -> Open -> Close) Ludu Arts'ın "Toggle" gereksinimine göre optimize edildi.





Prompt 16: ScriptableObject and Inventory System

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt kullandım

Benim Promptum: Kapı da tamam Animasyonda tamam şimdi kodlara geçelim.



Açıklama: Veri odaklı (Data-oriented) bir yapı için ItemData ScriptableObject sistemi kuruldu. Oyuncunun topladığı eşyaları takip eden Singleton InventoryController yapısı entegre edildi.

Alınan Cevap : 
using UnityEngine;



namespace MuratAltin.Runtime.Items

{

&nbsp;   \[CreateAssetMenu(fileName = "NewItem", menuName = "LuduArts/Item Data")]

&nbsp;   public class ItemData : ScriptableObject

&nbsp;   {

&nbsp;       #region Fields

&nbsp;       \[SerializeField] private string m\_ItemName;

&nbsp;       \[SerializeField] private string m\_ItemID; // Kapıdaki ID ile bu eşleşmeli

&nbsp;       #endregion



&nbsp;       #region Properties

&nbsp;       public string ItemName => m\_ItemName;

&nbsp;       public string ItemID => m\_ItemID;

&nbsp;       #endregion

&nbsp;   }

}


using System.Collections.Generic;

using UnityEngine;

using MuratAltin.Runtime.Items;



namespace MuratAltin.Runtime.Player

{

&nbsp;   public class InventoryController : MonoBehaviour

&nbsp;   {

&nbsp;       public static InventoryController Instance; // Singleton: Kapı her yerden erişebilsin



&nbsp;       \[SerializeField] private List<string> m\_CollectedItemIDs = new List<string>();



&nbsp;       private void Awake()

&nbsp;       {

&nbsp;           Instance = this;

&nbsp;       }



&nbsp;       public void AddItem(string itemID)

&nbsp;       {

&nbsp;           if (!m\_CollectedItemIDs.Contains(itemID))

&nbsp;               m\_CollectedItemIDs.Add(itemID);

&nbsp;       }



&nbsp;       public bool HasItem(string itemID)

&nbsp;       {

&nbsp;           return m\_CollectedItemIDs.Contains(itemID);

&nbsp;       }

&nbsp;   }

}

using UnityEngine;

using MuratAltin.Runtime.Core;

using MuratAltin.Runtime.Items;

using MuratAltin.Runtime.Player;



namespace MuratAltin.Runtime.Interactables

{

&nbsp;   public class KeyPickup : MonoBehaviour, IInteractable

&nbsp;   {

&nbsp;       \[SerializeField] private ItemData m\_Data;



&nbsp;       public string InteractionTitle => m\_Data.ItemName;

&nbsp;       public string InteractionDescription => "Topla";

&nbsp;       public bool CanInteract => true;



&nbsp;       public void Interact()

&nbsp;       {

&nbsp;           InventoryController.Instance.AddItem(m\_Data.ItemID);

&nbsp;           Debug.Log(m\_Data.ItemName + " envantere eklendi!");

&nbsp;           gameObject.SetActive(false); // Objeyi yok et veya deaktif et

&nbsp;       }

&nbsp;   }

}





Prompt 17: Locked Door and Key Requirement

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Fazladan Panel açmamıza gerek yok. Tek Text üzerinde halledelim.



Açıklama: "Must Have" listesindeki kilitli etkileşim gereksinimi tamamlandı. Door scripti InventoryController ile konuşturularak ID tabanlı kilit açma sistemi kuruldu. Mevcut UI sistemi dinamik yazı desteğiyle güncellendi.





Prompt 18: SOLID Principles and Refactoring

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt kullandım

Benim Promptum: Solid prensiplerine uygun yazalım. Senin yazdığında olmuyor o. Her scriptin tek bir görevi olsun.



Açıklama: Başlangıçtaki monolitik kilit yapısı, SOLID prensiplerine (özellikle SRP ve OCP) uygun şekilde refactor edildi. Gereksinim sistemi soyutlaştırılarak (InteractionRequirement) kapı mantığından tamamen ayrıştırıldı.
Alınan Cevap :
using UnityEngine;

using MuratAltin.Runtime.Core;



namespace MuratAltin.Runtime.Interactables

{

&nbsp;   public class Door : MonoBehaviour, IInteractable

&nbsp;   {

&nbsp;       #region Fields

&nbsp;       private Animator m\_Animator;

&nbsp;       \[SerializeField] private bool m\_IsOpen = false;

&nbsp;       

&nbsp;       // Dependency Inversion: Somut sınıfa değil, soyut sınıfa bağımlıyız.

&nbsp;       private InteractionRequirement m\_Requirement; 

&nbsp;       #endregion



&nbsp;       #region Properties

&nbsp;       public string InteractionTitle => "Kapı";

&nbsp;       public string InteractionDescription => GetDescription();

&nbsp;       public bool CanInteract => true;

&nbsp;       #endregion



&nbsp;       private void Awake()

&nbsp;       {

&nbsp;           m\_Animator = GetComponent<Animator>();

&nbsp;           m\_Requirement = GetComponent<InteractionRequirement>();

&nbsp;           SyncAnimator();

&nbsp;       }



&nbsp;       public void Interact()

&nbsp;       {

&nbsp;           // Eğer bir şart varsa ve sağlanmamışsa etkileşimi reddet

&nbsp;           if (m\_Requirement != null \&\& !m\_Requirement.IsMet())

&nbsp;           {

&nbsp;               Debug.Log(m\_Requirement.GetWarningMessage());

&nbsp;               return;

&nbsp;           }



&nbsp;           m\_IsOpen = !m\_IsOpen;

&nbsp;           SyncAnimator();

&nbsp;       }



&nbsp;       private string GetDescription()

&nbsp;       {

&nbsp;           if (m\_Requirement != null \&\& !m\_Requirement.IsMet()) 

&nbsp;               return m\_Requirement.GetWarningMessage();

&nbsp;               

&nbsp;           return m\_IsOpen ? "Kapat" : "Aç";

&nbsp;       }



&nbsp;       private void SyncAnimator() => m\_Animator.SetBool("m\_IsOpen", m\_IsOpen);

&nbsp;   }

}

using UnityEngine;

using MuratAltin.Runtime.Player;



namespace MuratAltin.Runtime.Core

{

&nbsp;   public class KeyRequirement : InteractionRequirement

&nbsp;   {

&nbsp;       \[SerializeField] private string m\_RequiredKeyID;



&nbsp;       public override bool IsMet() => InventoryController.Instance.HasItem(m\_RequiredKeyID);

&nbsp;       public override string GetWarningMessage() => "Anahtar Gerekli!";

&nbsp;   }

}

using UnityEngine;



namespace MuratAltin.Runtime.Core

{

&nbsp;   public abstract class InteractionRequirement : MonoBehaviour

&nbsp;   {

&nbsp;       public abstract bool IsMet();

&nbsp;       public abstract string GetWarningMessage();

&nbsp;   }

}





Prompt 19: Multiple Interactables and Requirement Validation

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Oluşturduğum iki kapıyı aynı animator üzerinden yapıyorum. Sorun olur mu ?

Açıklama: Sahnede kilitli ve kilitsiz olmak üzere iki farklı kapı prototipi kuruldu. SOLID prensiplerine uygun olarak tasarlanan Door sınıfının, üzerinde Requirement olan ve olmayan objelerdeki çalışma durumu doğrulandı. Modüler yapı sayesinde kod tekrarı olmadan farklı davranışlar elde edildi.





Prompt 20: Item Interaction and UI Synchronization

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt Kullandım.

Benim Promptum: Keyin yanına gidince yazı çıksın. Bunu yazar mısın ?



Açıklama: Toplanabilir eşyalar (KeyPickup) için dinamik UI başlıkları aktive edildi. KeyRequirement sınıfındaki ID eşleşme mantığı, boş veri girişlerine karşı daha dirençli hale getirilerek kullanıcı geri bildirimi (UI Text) stabilize edildi.

Alinan Cevap:

using UnityEngine;

using MuratAltin.Runtime.Core;

using MuratAltin.Runtime.Items;

using MuratAltin.Runtime.Player;



namespace MuratAltin.Runtime.Interactables

{

&nbsp;   public class KeyPickup : MonoBehaviour, IInteractable

&nbsp;   {

&nbsp;       \[SerializeField] private ItemData m\_Data;



&nbsp;       // Ekranda "Kırmızı Anahtar" gibi bir başlık yazar

&nbsp;       public string InteractionTitle => m\_Data != null ? m\_Data.ItemName : "Eşya";

&nbsp;       

&nbsp;       // Ekranda "\[E] Topla" yazar

&nbsp;       public string InteractionDescription => "Topla";

&nbsp;       

&nbsp;       public bool CanInteract => true;



&nbsp;       public void Interact()

&nbsp;       {

&nbsp;           if (m\_Data != null)

&nbsp;           {

&nbsp;               InventoryController.Instance.AddItem(m\_Data.ItemID);

&nbsp;               Debug.Log(m\_Data.ItemName + " toplandı!");

&nbsp;               gameObject.SetActive(false); // Objeyi sahneden kaldır

&nbsp;           }

&nbsp;       }

&nbsp;   }

}

using UnityEngine;

using MuratAltin.Runtime.Player;



namespace MuratAltin.Runtime.Core

{

&nbsp;   public class KeyRequirement : InteractionRequirement

&nbsp;   {

&nbsp;       \[SerializeField] private string m\_RequiredKeyID;



&nbsp;       public override bool IsMet()

&nbsp;       {

&nbsp;           // Envanter kontrolü

&nbsp;           if (InventoryController.Instance == null) return false;

&nbsp;           return InventoryController.Instance.HasItem(m\_RequiredKeyID);

&nbsp;       }



&nbsp;       public override string GetWarningMessage()

&nbsp;       {

&nbsp;           return "Anahtar Gerekli!";

&nbsp;       }

&nbsp;   }

}






Prompt 21: Debugging Inventory Logic and String Matching

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Keyi alsam da almasamda kapıda her türlü key gerekli diyor.



Açıklama: ID tabanlı kilit sistemindeki eşleşme hataları, string karşılaştırma (Trim) ve Singleton referans kontrolleriyle giderildi. KeyRequirement ve InventoryController arasındaki veri akışı doğrulandı.





Prompt 22: Switch and Hold Interaction Mechanics

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum:3. maddeye geçelim Switch mantığını da solid prensiplerine uygun kuralım.



Açıklama: UnityEvents kullanılarak esnek bir Switch sistemi kuruldu. Sandık etkileşimi için "Hold Interaction" mantığı geliştirildi ve InteractionDetector zaman tabanlı etkileşimleri destekleyecek şekilde güncellendi.





Prompt 23: Environment Interaction with UnityEvents

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Kapıdaki mantığın aynısı burada da kurulsun.



Açıklama: Dünya üzerindeki bir objeye (Küp) Switch scripti atanarak çevresel etkileşim sağlandı. UnityEvent yapısı kullanılarak kod bağımlılığı oluşturmadan Spot Light bileşeni tetiklendi.





Prompt 24: Toggle Logic for Environment Objects

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Kapıda ki gibi olmadı Tek bir kere açılıyor. Toogle mantığı kuralım.



Açıklama: Statik SetActive komutu yerine, objelerin durumunu tersine çeviren (Toggle) bir ToggleTool sınıfı yazıldı. Bu sayede şalterin (Switch) her kullanımda ışığı açıp kapatması sağlandı.





Prompt 25: Dynamic Switch Labels

Araç: Gemini 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Kapıdaki gibi olsun. Switch üzerinden anlık değişimler olsun.



Açıklama: Switch sınıfı, Door sınıfındaki toggle mantığına uygun olarak güncellendi. Kullanıcının ışığın o anki durumunu (Çalıştır/Kapat) UI üzerinden anlık olarak görebilmesi sağlandı.





Prompt 26: Implementing Hold Interaction and Progress UI

Araç: Gemini 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Bana bir tane Chest sistemi kur. Sliderlar hazır. Bunu HoldTimer yazıp kur. Ve IInteractable arayüzünü kullanalım.



Açıklama: IInteractable arayüzü zaman tabanlı etkileşimi destekleyecek şekilde genişletildi. InteractionDetector sınıfı, HoldTimer mantığıyla slider dolumunu ve süre sonunda tetiklenmeyi sağlayacak şekilde refactor edildi.





Prompt 27: Standardized Hold-to-Interact System

Araç: Gemini 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: Bu chest şi şöyle kuralım IInteractable interface si üzerinden kuralım.



Açıklama: InteractionDetector merkezi yönetim scripti temel alınarak tüm sistem refactor edildi. IInteractable interface'i üzerinden süre bazlı etkileşim (Hold Interaction) standardize edildi. Sandık etkileşimi Slider görselleştirmesiyle entegre edildi.





Prompt 28: Multi-Stage Chest Interaction

Araç: Gemini 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Adapte ettim

Benim Promptum: İçinden ıtem cıkıyor onu da alsın istiyorum. Ve açıldıktan sonra Sandık açıldı mesajı yerine Itemı almak ıcın E tuşuna basın çıksın istiyorum.



Açıklama: Chest sınıfı iki aşamalı etkileşimi (Açma ve Toplama) destekleyecek şekilde güncellendi. Dinamik InteractionDuration ve InteractionDescription mantığı kullanılarak kullanıcı deneyimi iyileştirildi.




# Kullanılan Yazılım Mimarisi ve Design Patternler

Proje geliştirilirken sürdürülebilir ve ölçeklenebilir bir yapı için aşağıdaki patternler uygulanmıştır:

* **Singleton:** `InventoryController` ile merkezi veri yönetimi.
* **Observer (via UnityEvents):** `Switch` sistemi ile nesneler arası gevşek bağlılık (Loose Coupling).
* **Interface-Driven Design:** `IInteractable` ile polimorfik etkileşim yönetimi.
* **SOLID Principles:** Özellikle *Single Responsibility* (Etkileşim ve Gereksinim ayrımı) ve *Open/Closed* (Yeni etkileşim türlerinin kod değiştirmeden eklenmesi) kuralları baz alınmıştır.
