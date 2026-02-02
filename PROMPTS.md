# LLM Kullanım Dokümantasyonu

## Özet
- Toplam prompt sayısı: 8
- Kullanılan araçlar: ChatGPT
- En çok yardım alınan konular:
  - Unity Interaction System mimarisi
  - Input System entegrasyonu
  - UI feedback ve state yönetimi
  - Trigger vs Raycast etkileşim yaklaşımları
  - Hold-to-interact mekanikleri

---

## Prompt 1: Unity Interaction System için Mimari Yaklaşım

**Araç:** ChatGPT  
**Tarih/Saat:** 2026-02-02 15:10

**Prompt:**
> Unity’de ölçeklenebilir bir interaction system kurmak istiyorum.  
> Trigger tabanlı mı, raycast tabanlı mı ilerlemeliyim?  
> Interface ve component bazlı bir mimari için nasıl bir yaklaşım önerirsin?

**Alınan Cevap (Özet):**
> Trigger tabanlı sistemin third-person ve proximity ağırlıklı oyunlarda daha stabil olduğu,  
> IInteractable gibi interface’lerle sistemin genişletilebilir kurulabileceği önerildi.

**Nasıl Kullandım:**
- [x] Adapte ettim

**Açıklama:**
> Raycast yerine trigger-based yaklaşımı seçtim ancak önerilen mimariyi  
> kendi UI ve input ihtiyaçlarıma göre sadeleştirdim.

---

## Prompt 2: Input System ile Inspector’dan Etkileşim Tuşu Yönetimi

**Araç:** ChatGPT  
**Tarih/Saat:** 2026-02-02 16:00

**Prompt:**
> Unity Input System kullanıyorum.  
> Etkileşim tuşunu kodda sabitlemek yerine Inspector’dan seçilebilir yapmak istiyorum.  
> InputActionReference kullanımı doğru bir yaklaşım mı?

**Alınan Cevap (Özet):**
> InputActionReference ile action bazlı input yönetiminin  
> hem Inspector hem de UI tarafında esneklik sağladığı belirtildi.

**Nasıl Kullandım:**
- [x] Direkt kullandım

**Açıklama:**
> Etkileşim tuşunu tamamen Input Actions asset üzerinden yöneterek  
> kodu input bağımlılığından arındırdım.

---

## Prompt 3: En Yakın Interactable Seçimi Problemi

**Araç:** ChatGPT  
**Tarih/Saat:** 2026-02-02 17:05

**Prompt:**
> Player aynı anda birden fazla interactable trigger alanındayken  
> hangisiyle etkileşime gireceğini nasıl seçmeliyim?  
> Performans ve okunabilirlik açısından önerin nedir?

**Alınan Cevap (Özet):**
> Trigger içindeki adayları listeleyip mesafeye göre en yakını seçmenin  
> okunabilir ve güvenli bir yöntem olduğu önerildi.

**Nasıl Kullandım:**
- [x] Adapte ettim

**Açıklama:**
> Önerilen yaklaşımı kullanarak InteractionDetector içinde  
> nearest selection mantığını kurdum.

---

## Prompt 4: Otomatik Pickup (Key) Mekaniği

**Araç:** ChatGPT  
**Tarih/Saat:** 2026-02-02 18:10

**Prompt:**
> Bazı objelerin (örneğin anahtar) E’ye basmadan,  
> trigger alanına girince otomatik alınmasını istiyorum.  
> Bu durumu mevcut interaction sistemine nasıl entegre edebilirim?

**Alınan Cevap (Özet):**
> Ayrı bir interface (ör. IAutoCollectable) ile  
> press interaction’dan ayrıştırılması önerildi.

**Nasıl Kullandım:**
- [x] Adapte ettim

**Açıklama:**
> Otomatik pickup’ı ayrı bir interface ile ayırarak  
> sistemin açık/kapalı prensibine uygun hale getirdim.

---

## Prompt 5: Inventory State ve UI Senkronizasyonu

**Araç:** ChatGPT  
**Tarih/Saat:** 2026-02-02 19:00

**Prompt:**
> Basit bir inventory state (ör. key var/yok) UI ile nasıl senkron tutulmalı?  
> Polling mi event-based mi tercih edilmeli?

**Alınan Cevap (Özet):**
> Event-based yaklaşımın UI güncellemeleri için daha güvenli olduğu belirtildi.

**Nasıl Kullandım:**
- [x] Direkt kullandım

**Açıklama:**
> PlayerInventory içinde event tanımlayarak  
> UI bileşenlerinin state değişimlerini dinlemesini sağladım.

---

## Prompt 6: Hold-to-Interact Mekaniği Tasarımı

**Araç:** ChatGPT  
**Tarih/Saat:** 2026-02-02 20:15

**Prompt:**
> Sandık gibi objeler için “basılı tutarak etkileşim” mekaniği kurmak istiyorum.  
> Progress bar, tuş bırakıldığında resetlenme gibi edge-case’leri  
> nasıl ele almalıyım?

**Alınan Cevap (Özet):**
> Hold süresinin PlayerInteractor tarafında yönetilmesi,  
> progress UI’ın ayrı bir component olması önerildi.

**Nasıl Kullandım:**
- [x] Adapte ettim

**Açıklama:**
> Hold mantığını PlayerInteractor’a alarak  
> interactable’ların sadece davranıştan sorumlu olmasını sağladım.

---

## Prompt 7: UI Prompt Metinlerini Dinamik Hale Getirme

**Araç:** ChatGPT  
**Tarih/Saat:** 2026-02-02 21:00

**Prompt:**
> UI’da “Press E to interact” yerine  
> objeye göre değişen metinler göstermek istiyorum  
> (ör. open chest, turn light on).  
> Bunu nasıl soyutlamalıyım?

**Alınan Cevap (Özet):**
> Prompt metni için ayrı bir interface kullanmanın  
> interaction sistemini bozmadan çözüm sunduğu belirtildi.

**Nasıl Kullandım:**
- [x] Adapte ettim

**Açıklama:**
> IInteractionPromptProvider ile  
> UI metinlerini interaction’dan ayrıştırdım.

---

## Prompt 8: Lever (Toggle) Interaction ve Dünya Objesi Kontrolü

**Araç:** ChatGPT  
**Tarih/Saat:** 2026-02-02 22:00

**Prompt:**
> Minecraft benzeri bir lever yapmak istiyorum.  
> E’ye basıldığında ışık açılıp kapanacak,  
> aynı UI prompt sistemi kullanılacak.  
> Bunu mevcut mimariye nasıl ekleyebilirim?

**Alınan Cevap (Özet):**
> Lever’ın IInteractable üzerinden toggle davranışı uygulaması  
> ve UI prompt sistemini yeniden kullanması önerildi.

**Nasıl Kullandım:**
- [x] Direkt kullandım

**Açıklama:**
> Lever’ı mevcut interaction altyapısına ekleyerek  
> yeni sistem yazmadan reuse ettim.
