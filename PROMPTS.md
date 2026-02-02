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





Prompt 11: Basic Player Controller and Movement

Araç: Gemini Tarih: 2026-02-02

\*\*Nasıl Kullandım:\*\*

\- \[x] Direkt kullandım

Benim Promptum: Basic bir tane CharacaterController scripti yazar mısın?

Açıklama: Test sürecini kolaylaştırmak için CharacterController tabanlı, FPS bakış açısına uygun hareket ve bakış sistemi (PlayerController) eklendi. Mouse Lock ve Movement entegrasyonu sağlandı.





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

