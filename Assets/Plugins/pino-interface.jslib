mergeInto(LibraryManager.library, {
  RegisterRankingKey: function (rankingKey) {
    if (window.pinoGameJSLibRegisterRankingKey) {
      window.pinoGameJSLibRegisterRankingKey(Pointer_stringify(rankingKey));
    }
  },
  RegisterScore: function (score) {
    if (window.pinoGameJSLibRegisterScore) {
      window.pinoGameJSLibRegisterScore(score);
    }
  },
  ShareResult: function (text) {
    if (window.pinoGameJSLibShareResult) {
      window.pinoGameJSLibShareResult(Pointer_stringify(text));
    }
  },
  QuitGame: function () {
    if (window.pinoGameJSLibQuitGame) {
      window.pinoGameJSLibQuitGame();
    }
  }
});
