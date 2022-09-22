mergeInto(LibraryManager.library, {
  RegisterRankingKey: function (rankingKey) {
    if (window.pinoGameJSLibRegisterRankingKey) {
//      window.pinoGameJSLibRegisterRankingKey(Pointer_stringify(rankingKey));
      window.pinoGameJSLibRegisterRankingKey(UTF8ToString(rankingKey));
    }
  },
  RegisterScore: function (score) {
    if (window.pinoGameJSLibRegisterScore) {
      window.pinoGameJSLibRegisterScore(score);
    }
  },
  GetHighscore: function (text) {
    if (window.pinoGameJSLibGetHighscore) {
      return window.pinoGameJSLibGetHighscore(Pointer_stringify(text));
    }
    return -1;
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
