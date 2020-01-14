using System;
using NFluent;
using Xunit;

namespace dddbits.Basetypes
{
    public class EntityTest
    {
        class ConcreteEntity : Entity<long> 
         {
 
             public ConcreteEntity(long id) : base(id)
             {
             }
 		    
         }
 
        class ConcreteEntity2 : Entity<long> 
        {

	        public ConcreteEntity2(long id) : base(id)
	        {
	        }
		    
        }

        [Fact]
        public void givenANewEntity_whenGetId_thenEqual()
        {
            // given
            var entityUnderTest = new ConcreteEntity(47L)
            {
            };
		        
            // when
            var id = entityUnderTest.Identity;
		        
            // then
            Check.That(id).IsEqualTo(47L);
        }
        
        [Fact]
        void givenTwoEntitiesOfSameTypeWithSameId_whenEquals_thenTrue() {
            // given
            var entity1 = new ConcreteEntity(47L);
            var entity2 = new ConcreteEntity(47L);
		
            // when
            bool equal = entity1.Equals(entity2);
		
            // then
            Check.That(equal).IsTrue();
        }
	
        [Fact]
        void givenTwoEntitiesOfDifferentTypeWithSameId_whenEquals_thenFalse() {
            // given
            var entity1 = new ConcreteEntity(47L) { };
            var entity2 = new ConcreteEntity2(47L) { };
		
            // when
            bool equal = entity1.Equals(entity2);
		
            // then
            Check.That(equal).IsFalse();
        }
	
        [Fact]
        void givenAnEntity_whenToString_thenClassnamePlusId() {
            // given
            var entityUnderTest = new ConcreteEntity(47L);
		
            // when
            string entityAsString = entityUnderTest.ToString();
		
            // then
            Check.That(entityAsString).IsEqualTo("ConcreteEntity [id=47]");
        }
	
    }
}