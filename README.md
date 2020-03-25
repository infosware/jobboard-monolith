# jobboard-monolith
A simple ASP.NET Web API that gathers job vacancies from different public APIs 

ASP.NET Web Api сервис, который возвращает IT вакансии с разных API (jobs.github.com, hh.ru).
При старте приложения, для каждого API запускаются отдельные таски, которые каждые N минут собирают вакансии и записывают в объект SingletoneCache. SingletoneCache служит подобием кэша (в идеале нужен Redis или аналог).
Api контроллер api/jobs при GET запросе выдаст json со всеми вакансиями из кэша.
