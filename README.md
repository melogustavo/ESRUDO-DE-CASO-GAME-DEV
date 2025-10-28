# StarRunner 2D — Unity 2D Platformer (Starter Package)

Este pacote contém:
- **Projeto Unity (esqueleto)** com **scripts C# prontos** (movimento: andar/correr/pular/escalar, inimigos, plataformas móveis, coletáveis, HUD, áudio, checkpoints, fim de fase).
- **Modelos de documentação**: README do jogo, CREDITS, Relatório Teórico (para PDF).
- **Template WebGL** para publicar e testar no navegador.
- **Script de servidor local** para servir o build WebGL rapidamente.
- **Exemplo de GitHub Actions** para publicar no GitHub Pages.

> Observação: Este repositório é um *starter*. Abra na Unity (2D LTS), crie as cenas, ajuste os prefabs e faça o **Build para WebGL** em `UnityProject/Builds/WebGL`. Depois use o template de hospedagem.

## 1) Requisitos
- Unity 2022 LTS ou 2023 LTS (template **2D**)
- (Opcional) Python 3 para o servidor local
- (Opcional) Git e GitHub para deploy Pages

## 2) Como abrir na Unity
1. Abra o **Unity Hub** → **Open** → selecione a pasta `UnityProject` deste pacote.
2. Importe/Crie as cenas: `MainMenu`, `Level1`, `Level2`, `Level3`, `GameOver`, `Victory` (em `Assets/Scenes/`).
3. Adicione os scripts em objetos apropriados (Player, GameManager, etc.).
4. Configure **Layers/Tags** conforme indicado nos comentários dos scripts.

## 3) Build para WebGL
1. No Unity Hub, instale o **módulo WebGL Build Support**.
2. Unity: `File > Build Settings > WebGL > Switch Platform`.
3. `Add Open Scenes` e **Build** para `UnityProject/Builds/WebGL/`.
4. Teste localmente e/ou publique (veja abaixo).

## 4) Servir localmente o WebGL (navegador)
- Método Python (recomendado, sem instalar nada além do Python):
  ```bash
  cd tools
  python serve_webgl.py ../UnityProject/Builds/WebGL 8080
  ```
  Abra `http://localhost:8080` no navegador.

## 5) Publicar no GitHub Pages
1. Suba o repositório para o GitHub.
2. Garanta que o build está em `UnityProject/Builds/WebGL`.
3. Habilite Pages (Settings → Pages → Build and deployment → **GitHub Actions**).
4. O workflow `.github/workflows/deploy-pages.yml` deste pacote já publica os arquivos do build para o Pages.

## 6) Estrutura
```
StarRunner2D_Package/
  UnityProject/
    Assets/
      Scripts/ (C# prontos)
      Scenes/ (suas cenas)
      ...
    Builds/WebGL/ (gerado pela Unity)
  WebGL_Template/ (HTML estático para servir o build)
  tools/serve_webgl.py (servidor local)
  .github/workflows/deploy-pages.yml (deploy automático)
  GAME_README.md (README do jogo para seu repositório final)
  REPORT_TEMPLATE.md (relatório teórico para PDF)
  CREDITS.md (créditos de assets)
```

## 7) Créditos de assets
Liste os autores/links no arquivo `CREDITS.md`. Use pacotes como Kenney.nl, OpenGameArt.org, Freesound.org, itch.io (free).

## 8) Próximos passos sugeridos
- Criar prefabs (Player, InimigoPatrulha, PlataformaMóvel, Coletável, Checkpoint, GoalFlag).
- Adicionar **TextMeshPro** para UI (HUD).
- Implementar **3 níveis** com progressão.
- Exportar **build Windows** (executável) além do WebGL, se sua entrega exigir.

Bom desenvolvimento! 🚀
