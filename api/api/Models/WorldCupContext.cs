using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Models
{
    public partial class WorldCupContext : DbContext
    {
        public WorldCupContext()
        {
        }

        public WorldCupContext(DbContextOptions<WorldCupContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionUser> QuestionUsers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VwJogo> VwJogos { get; set; }
        public virtual DbSet<VwJogo2> VwJogo2s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=WorldCup;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasKey(e => e.IdCompetition)
                    .HasName("PK_Competicao");

                entity.ToTable("Competition");

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.IdGame)
                    .HasName("PK_Jogos");

                entity.Property(e => e.IdGame).HasColumnName("idGame");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.IdCompetition).HasColumnName("idCompetition");

                entity.HasOne(d => d.IdCompetitionNavigation)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.IdCompetition)
                    .HasConstraintName("FK_Jogos_Competicao");

                entity.HasOne(d => d.Team1Navigation)
                    .WithMany(p => p.GameTeam1Navigations)
                    .HasForeignKey(d => d.Team1)
                    .HasConstraintName("FK_Jogos_Selecao1");

                entity.HasOne(d => d.Team2Navigation)
                    .WithMany(p => p.GameTeam2Navigations)
                    .HasForeignKey(d => d.Team2)
                    .HasConstraintName("FK_Jogos_Selecao2");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.ToTable("Notification");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateHour)
                    .HasColumnType("datetime")
                    .HasColumnName("dateHour");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.NotificationMessage)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("notificationMessage");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notificacao_Usuarios");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(e => e.IdQuestion)
                    .HasName("PK_Pergunta");

                entity.ToTable("Question");

                entity.Property(e => e.IdQuestion).HasColumnName("idQuestion");

                entity.Property(e => e.Field)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("field");

                entity.Property(e => e.Question1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("question");

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("type");
            });

            modelBuilder.Entity<QuestionUser>(entity =>
            {
                entity.HasKey(e => e.IdQuestionUser)
                    .HasName("PK_PerguntaUsuario_1");

                entity.ToTable("Question_User");

                entity.Property(e => e.IdQuestionUser).HasColumnName("idQuestion_User");

                entity.Property(e => e.IdQuestion).HasColumnName("idQuestion");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.HasOne(d => d.IdQuestionNavigation)
                    .WithMany(p => p.QuestionUsers)
                    .HasForeignKey(d => d.IdQuestion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PerguntaUsuario_Pergunta");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.QuestionUsers)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_PerguntaUsuario_Usuarios");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.IdTeam)
                    .HasName("PK_Selecao");

                entity.ToTable("Team");

                entity.Property(e => e.Flag).HasColumnType("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_Usuarios");

                entity.ToTable("User");

                entity.Property(e => e.Birthday)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("birthday")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FavoriteColor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("favoriteColor");

                entity.Property(e => e.FavoriteTeam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("favoriteTeam")
                    .HasDefaultValueSql("('Brasil')");

                entity.Property(e => e.IdIndicated).HasColumnName("idIndicated");

                entity.Property(e => e.InviteDate)
                    .HasColumnType("datetime")
                    .HasColumnName("inviteDate");

                entity.Property(e => e.Nickname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nickname");

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.ReceiveNotification)
                    .HasColumnName("receiveNotification")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Senha)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SignupDate)
                    .HasColumnType("datetime")
                    .HasColumnName("signupDate");

                entity.HasOne(d => d.IdIndicatedNavigation)
                    .WithMany(p => p.InverseIdIndicatedNavigation)
                    .HasForeignKey(d => d.IdIndicated)
                    .HasConstraintName("FK_Usuarios_Usuarios");
            });

            modelBuilder.Entity<VwJogo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Jogo");

                entity.Property(e => e.Data)
                    .HasMaxLength(4000)
                    .HasColumnName("data");

                entity.Property(e => e.Hora)
                    .HasMaxLength(4000)
                    .HasColumnName("hora");

                entity.Property(e => e.IdCompeticao).HasColumnName("idCompeticao");

                entity.Property(e => e.IdJogo).HasColumnName("idJogo");

                entity.Property(e => e.Time1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Time2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.X)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("x");
            });

            modelBuilder.Entity<VwJogo2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_Jogo2");

                entity.Property(e => e.Data)
                    .HasMaxLength(4000)
                    .HasColumnName("data");

                entity.Property(e => e.Hora)
                    .HasMaxLength(4000)
                    .HasColumnName("hora");

                entity.Property(e => e.IdCompeticao).HasColumnName("idCompeticao");

                entity.Property(e => e.IdJogo).HasColumnName("idJogo");

                entity.Property(e => e.Time2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.X)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
